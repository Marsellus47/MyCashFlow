using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Web.Models.Manage;
using MyCashFlow.Web.ViewModels.Manage;
using Rsx = MyCashFlow.Resources.Localization.Views.Manage;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MyCashFlow.Web.Services.Manage
{
	public class ManageService : IManageService
	{
		public async Task<IndexViewModel> BuildIndexViewModelAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			IAuthenticationManager authenticationManager,
			ManageMessageId? message)
		{
			var userId = GetUserId(principal);
			var model = new IndexViewModel
			{
				HasPassword = HasPassword(currentUser),
				PhoneNumber = await userManager.GetPhoneNumberAsync(userId),
				TwoFactor = await userManager.GetTwoFactorEnabledAsync(userId),
				Logins = await userManager.GetLoginsAsync(userId),
				BrowserRemembered = await authenticationManager.TwoFactorBrowserRememberedAsync(userId),
				StatusMessage =
					message == ManageMessageId.ChangePasswordSuccess ? Rsx.Index.ChangePasswordSuccess
					: message == ManageMessageId.SetPasswordSuccess ? Rsx.Index.SetPasswordSuccess
					: message == ManageMessageId.SetTwoFactorSuccess ? Rsx.Index.SetTwoFactorSuccess
					: message == ManageMessageId.Error ? Rsx.Index.Error
					: message == ManageMessageId.AddPhoneSuccess ? Rsx.Index.AddPhoneSuccess
					: message == ManageMessageId.RemovePhoneSuccess ? Rsx.Index.RemovePhoneSuccess
					: ""
			};

			return model;
		}

		public async Task<ManageMessageId> RemoveLoginAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			string loginProvider,
			string providerKey)
		{
			ManageMessageId message;
			var result = await userManager.RemoveLoginAsync(GetUserId(principal), new UserLoginInfo(loginProvider, providerKey));
			if (result.Succeeded)
			{
				await TrySignInAsync(signInManager, currentUser);
				message = ManageMessageId.RemoveLoginSuccess;
			}
			else
			{
				message = ManageMessageId.Error;
			}
			return message;
		}

		public async Task SendSmsTokenAsync(
			IPrincipal principal,
			UserManager<User> userManager,
			AddPhoneNumberViewModel model)
		{
			// Generate the token and send it
			var code = await userManager.GenerateChangePhoneNumberTokenAsync(GetUserId(principal), model.Number);
			if (userManager.SmsService != null)
			{
				var message = new IdentityMessage
				{
					Destination = model.Number,
					Body = string.Format(Rsx.AddPhoneNumber.SecurityCodeSmsMessage, code)
				};
				await userManager.SmsService.SendAsync(message);
			}
		}

		public async Task SetTwoFactorAuthenticationAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			bool enabled)
		{
			await userManager.SetTwoFactorEnabledAsync(GetUserId(principal), enabled);
			await TrySignInAsync(signInManager, currentUser);
		}

		public async Task<VerifyPhoneNumberViewModel> BuildVerifyPhoneNumberViewModelAsync(
			IPrincipal principal,
			UserManager<User> userManager,
			string phoneNumber)
		{
			var code = await userManager.GenerateChangePhoneNumberTokenAsync(GetUserId(principal), phoneNumber);
			// Send an SMS through the SMS provider to verify the phone number

			var model = new VerifyPhoneNumberViewModel
			{
				PhoneNumber = phoneNumber
			};
			return model;
		}

		public async Task<IdentityResult> VerifyPhoneNumberAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			VerifyPhoneNumberViewModel model)
		{
			var result = await userManager.ChangePhoneNumberAsync(GetUserId(principal), model.PhoneNumber, model.Code);
			if (result.Succeeded)
			{
				await TrySignInAsync(signInManager, currentUser);
				return IdentityResult.Success;
			}
			return result;
		}

		public async Task<IdentityResult> RemovePhoneNumberAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager)
		{
			var result = await userManager.SetPhoneNumberAsync(GetUserId(principal), null);
			if (result.Succeeded)
			{
				await TrySignInAsync(signInManager, currentUser);
			}
			return result;
		}

		public async Task<IdentityResult> ChangePasswordAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			ChangePasswordViewModel model)
		{
			var result = await userManager.ChangePasswordAsync(GetUserId(principal), model.OldPassword, model.NewPassword);
			if (result.Succeeded)
			{
				await TrySignInAsync(signInManager, currentUser);
			}
			return result;
		}

		public async Task<IdentityResult> SetPasswordAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			SetPasswordViewModel model)
		{
			var result = await userManager.AddPasswordAsync(GetUserId(principal), model.NewPassword);
			if (result.Succeeded)
			{
				await TrySignInAsync(signInManager, currentUser);
			}
			return result;
		}

		public async Task<ManageLoginsViewModel> BuildManageLoginsAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			IAuthenticationManager authenticationManager,
			ManageMessageId? message)
		{
			if (currentUser == null)
			{
				return null;
			}

			var userLogins = await userManager.GetLoginsAsync(GetUserId(principal));
			var otherLogins = authenticationManager
				.GetExternalAuthenticationTypes()
				.Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider))
				.ToList();

			var model = new ManageLoginsViewModel
			{
				StatusMessage =
					message == ManageMessageId.RemoveLoginSuccess ? Rsx.ManageLogins.LoginRemoved
					: message == ManageMessageId.Error ? Rsx.ManageLogins.Error
					: "",
				CurrentLogins = userLogins,
				OtherLogins = otherLogins,
				ShowRemoveButton = currentUser.PasswordHash != null || userLogins.Count > 1
			};
			return model;
		}

		public async Task<IdentityResult> LinkLoginAsync(
			IPrincipal principal,
			UserManager<User> userManager,
			IAuthenticationManager authenticationManager)
		{
			const string XsrfKey = "XsrfId";
			var loginInfo = await authenticationManager.GetExternalLoginInfoAsync(XsrfKey, GetUserId(principal));
			if (loginInfo == null)
			{
				return null;
			}

			var result = await userManager.AddLoginAsync(GetUserId(principal), loginInfo.Login);
			return result;
		}

		#region Helpers

		private string GetUserId(IPrincipal principal)
		{
			var userId = principal.Identity.GetUserId();
			return userId;
		}

		private bool HasPassword(User user)
		{
			if (user != null)
			{
				return user.PasswordHash != null;
			}
			return false;
		}

		private async Task TrySignInAsync(
			SignInManager<User, string> signInManager,
			User currentUser)
		{
			if (currentUser != null)
			{
				await signInManager.SignInAsync(currentUser, isPersistent: false, rememberBrowser: false);
			}
		}

		#endregion
	}
}
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MyCashFlow.Identity.Managers;
using MyCashFlow.Web.Infrastructure.Controllers;
using MyCashFlow.Web.Models.Manage;
using MyCashFlow.Web.Services.Manage;
using MyCashFlow.Web.ViewModels.Manage;
using Resource = MyCashFlow.Resources.Localization.Views.Manage;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System;

namespace MyCashFlow.Web.Controllers
{
	public partial class ManageController : UserManagerBasedController
	{
		private ApplicationSignInManager _signInManager;
		private readonly IManageService _manageService;

		public ManageController(IManageService manageService)
			: this(manageService, null, null) { }

		public ManageController(
			IManageService manageService,
			ApplicationUserManager userManager,
			ApplicationSignInManager signInManager)
			: base(userManager)
		{
			if(manageService == null)
			{
				throw new ArgumentNullException(nameof(manageService));
			}

			_manageService = manageService;
			SignInManager = signInManager;
		}

		public ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
			}
			private set
			{
				_signInManager = value;
			}
		}

		public virtual async Task<ActionResult> Index(ManageMessageId? message)
		{
			var model = await _manageService.BuildIndexViewModelAsync(User, GetCurrentUser(), UserManager, AuthenticationManager, message);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
		{
			var message = await _manageService.RemoveLoginAsync(User, GetCurrentUser(), UserManager, SignInManager, loginProvider, providerKey);
			return RedirectToAction(MVC.Manage.ActionNames.ManageLogins, new { Message = message });
		}

		public virtual ActionResult AddPhoneNumber()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _manageService.SendSmsTokenAsync(User, UserManager, model);
			return RedirectToAction(MVC.Manage.ActionNames.VerifyPhoneNumber, new { PhoneNumber = model.Number });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> EnableTwoFactorAuthentication()
		{
			await _manageService.SetTwoFactorAuthenticationAsync(User, await GetCurrentUserAsync(), UserManager, SignInManager, true);
			return RedirectToAction(MVC.Manage.ActionNames.Index, MVC.Manage.Name);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> DisableTwoFactorAuthentication()
		{
			await _manageService.SetTwoFactorAuthenticationAsync(User, await GetCurrentUserAsync(), UserManager, SignInManager, false);
			return RedirectToAction(MVC.Manage.ActionNames.Index, MVC.Manage.Name);
		}

		public virtual async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
		{
			var model = await _manageService.BuildVerifyPhoneNumberViewModelAsync(User, UserManager, phoneNumber);
			return phoneNumber == null ? View(MVC.Shared.Views.Error) : View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _manageService.VerifyPhoneNumberAsync(User, await GetCurrentUserAsync(), UserManager, SignInManager, model);
			if (result.Succeeded)
			{
				return RedirectToAction(MVC.Manage.ActionNames.Index, new { Message = ManageMessageId.AddPhoneSuccess });
			}
			// If we got this far, something failed, redisplay form
			ModelState.AddModelError("", Resource.VerifyPhoneNumber.FailedToVerifyPhone);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> RemovePhoneNumber()
		{
			var result = await _manageService.RemovePhoneNumberAsync(User, await GetCurrentUserAsync(), UserManager, SignInManager);
			if(result.Succeeded)
			{
				return RedirectToAction(MVC.Manage.ActionNames.Index, new { Message = ManageMessageId.RemovePhoneSuccess });
			}

			return RedirectToAction(MVC.Manage.ActionNames.Index, new { Message = ManageMessageId.Error });
		}

		public virtual ActionResult ChangePassword()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _manageService.ChangePasswordAsync(User, await GetCurrentUserAsync(), UserManager, SignInManager, model);
			if (result.Succeeded)
			{
				return RedirectToAction(MVC.Manage.ActionNames.Index, new { Message = ManageMessageId.ChangePasswordSuccess });
			}
			AddErrors(result);
			return View(model);
		}

		public virtual ActionResult SetPassword()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> SetPassword(SetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _manageService.SetPasswordAsync(User, await GetCurrentUserAsync(), UserManager, SignInManager, model);
				if (result.Succeeded)
				{
					return RedirectToAction(MVC.Manage.ActionNames.Index, new { Message = ManageMessageId.SetPasswordSuccess });
				}
				AddErrors(result);
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		public virtual async Task<ActionResult> ManageLogins(ManageMessageId? message)
		{
			var model = await _manageService.BuildManageLoginsAsync(User, await GetCurrentUserAsync(), UserManager, AuthenticationManager, message);
			if (model == null)
			{
				return View(MVC.Shared.Views.Error);
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult LinkLogin(string provider)
		{
			// Request a redirect to the external login provider to link a login for the current user
			return new AccountController.ChallengeResult(provider, Url.Action(MVC.Manage.ActionNames.LinkLoginCallback, MVC.Manage.Name), User.Identity.GetUserId());
		}

		public virtual async Task<ActionResult> LinkLoginCallback()
		{
			var result = await _manageService.LinkLoginAsync(User, UserManager, AuthenticationManager);
			return result == null || !result.Succeeded
				? RedirectToAction(MVC.Manage.ActionNames.ManageLogins, new { Message = ManageMessageId.Error })
				: RedirectToAction(MVC.Manage.ActionNames.ManageLogins);
		}

		#region Helpers

		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}

		#endregion
	}
}
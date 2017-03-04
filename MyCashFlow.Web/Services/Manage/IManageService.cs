using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Web.Models.Manage;
using MyCashFlow.Web.ViewModels.Manage;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MyCashFlow.Web.Services.Manage
{
	public interface IManageService
	{
		Task<IndexViewModel> BuildIndexViewModelAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			IAuthenticationManager authenticationManager,
			ManageMessageId? message);

		Task<ManageMessageId> RemoveLoginAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			string loginProvider,
			string providerKey);

		Task SendSmsTokenAsync(
			IPrincipal principal,
			UserManager<User> userManager,
			AddPhoneNumberViewModel model);

		Task SetTwoFactorAuthenticationAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			bool enabled);

		Task<VerifyPhoneNumberViewModel> BuildVerifyPhoneNumberViewModelAsync(
			IPrincipal principal,
			UserManager<User> userManager,
			string phoneNumber);

		Task<IdentityResult> VerifyPhoneNumberAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			VerifyPhoneNumberViewModel model);

		Task<IdentityResult> RemovePhoneNumberAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager);

		Task<IdentityResult> ChangePasswordAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			ChangePasswordViewModel model);

		Task<IdentityResult> SetPasswordAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			SetPasswordViewModel model);

		Task<ManageLoginsViewModel> BuildManageLoginsAsync(
			IPrincipal principal,
			User currentUser,
			UserManager<User> userManager,
			IAuthenticationManager authenticationManager,
			ManageMessageId? message);

		Task<IdentityResult> LinkLoginAsync(
			IPrincipal principal,
			UserManager<User> userManager,
			IAuthenticationManager authenticationManager);
	}
}

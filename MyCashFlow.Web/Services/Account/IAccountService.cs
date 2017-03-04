using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Web.ViewModels.Account;
using System.Threading.Tasks;

namespace MyCashFlow.Web.Services.Account
{
	public interface IAccountService
	{
		VerifyCodeViewModel BuildVerifyCodeViewModel(
			string provider,
			string returnUrl,
			bool rememberMe);

		Task<IdentityResult> RegisterUserAsync(
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			RegisterViewModel model);

		Task<IdentityResult> ResetPasswordAsync(
			UserManager<User> userManager,
			ResetPasswordViewModel model);

		Task<SendCodeViewModel> BuildSendCodeViewModelAsync(
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			string returnUrl,
			bool rememberMe);

		Task<IdentityResult> ConfirmExternalLogin(
			IAuthenticationManager authenticationManager,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			ExternalLoginConfirmationViewModel model);
	}
}

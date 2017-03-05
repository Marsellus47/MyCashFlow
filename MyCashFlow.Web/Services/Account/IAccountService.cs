using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Web.ViewModels.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCashFlow.Web.Services.Account
{
	public interface IAccountService
	{
		RegisterViewModel BuildRegisterViewModel();

		IEnumerable<Country> GetCountries();

		VerifyCodeViewModel BuildVerifyCodeViewModel(
			string provider,
			string returnUrl,
			bool rememberMe);

		Task<IdentityResult> RegisterUserAsync(
			UserManager<User, int> userManager,
			SignInManager<User, int> signInManager,
			RegisterViewModel model);

		Task<IdentityResult> ResetPasswordAsync(
			UserManager<User, int> userManager,
			ResetPasswordViewModel model);

		Task<SendCodeViewModel> BuildSendCodeViewModelAsync(
			UserManager<User, int> userManager,
			SignInManager<User, int> signInManager,
			string returnUrl,
			bool rememberMe);

		Task<IdentityResult> ConfirmExternalLoginAsync(
			IAuthenticationManager authenticationManager,
			UserManager<User, int> userManager,
			SignInManager<User, int> signInManager,
			ExternalLoginConfirmationViewModel model);
	}
}

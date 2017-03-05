using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MyCashFlow.Identity.Managers;
using MyCashFlow.Web.Infrastructure.Controllers;
using MyCashFlow.Web.Services.Account;
using MyCashFlow.Web.ViewModels.Account;
using Rsx = MyCashFlow.Resources.Localization.Views.Account;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System;

namespace MyCashFlow.Web.Controllers
{
	public partial class AccountController : UserManagerBasedController
	{
		private ApplicationSignInManager _signInManager;
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
			: this(accountService, null, null) { }

		public AccountController(
			IAccountService accountService,
			ApplicationUserManager userManager,
			ApplicationSignInManager signInManager)
			: base(userManager)
		{
			if (accountService == null)
			{
				throw new ArgumentNullException(nameof(accountService));
			}

			_accountService = accountService;
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

		[AllowAnonymous]
		public virtual ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			// This doesn't count login failures towards account lockout
			// To enable password failures to trigger account lockout, change to shouldLockout: true
			var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
			switch (result)
			{
				case SignInStatus.Success:
					return RedirectToLocal(returnUrl);
				case SignInStatus.LockedOut:
					return View(MVC.Shared.Views.Lockout);
				case SignInStatus.RequiresVerification:
					return RedirectToAction(MVC.Account.ActionNames.SendCode, new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
				case SignInStatus.Failure:
				default:
					ModelState.AddModelError("", Rsx.Login.InvalidLoginAttempt);
					return View(model);
			}
		}

		[AllowAnonymous]
		public virtual async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
		{
			// Require that the user has already logged in via username/password or external login
			if (!await SignInManager.HasBeenVerifiedAsync())
			{
				return View(MVC.Shared.Views.Error);
			}
			var model = _accountService.BuildVerifyCodeViewModel(provider, returnUrl, rememberMe);
			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			// The following code protects for brute force attacks against the two factor codes. 
			// If a user enters incorrect codes for a specified amount of time then the user account 
			// will be locked out for a specified amount of time. 
			// You can configure the account lockout settings in IdentityConfig
			var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
			switch (result)
			{
				case SignInStatus.Success:
					return RedirectToLocal(model.ReturnUrl);
				case SignInStatus.LockedOut:
					return View(MVC.Shared.Views.Lockout);
				case SignInStatus.Failure:
				default:
					ModelState.AddModelError("", Rsx.VerifyCode.InvalidCode);
					return View(model);
			}
		}

		[AllowAnonymous]
		public virtual ActionResult Register()
		{
			var model = _accountService.BuildRegisterViewModel();
			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _accountService.RegisterUserAsync(UserManager, SignInManager, model);
				if (result.Succeeded)
				{
					return RedirectToAction(MVC.User.ActionNames.Index, MVC.User.Name);
				}
				AddErrors(result);
			}

			// If we got this far, something failed, redisplay form
			model.Countries = _accountService.GetCountries();
			return View(model);
		}

		[AllowAnonymous]
		public virtual async Task<ActionResult> ConfirmEmail(int userId, string code)
		{
			if (userId == null || code == null)
			{
				return View(MVC.Shared.Views.Error);
			}
			var result = await UserManager.ConfirmEmailAsync(userId, code);
			return View(result.Succeeded ? MVC.Account.Views.ConfirmEmail : MVC.Shared.Views.Error);
		}

		[AllowAnonymous]
		public virtual ActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await UserManager.FindByNameAsync(model.Email);
				if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
				{
					// Don't reveal that the user does not exist or is not confirmed
					return View(MVC.Account.Views.ForgotPasswordConfirmation);
				}

				// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
				// Send an email with this link
				// string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
				// var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
				// await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
				// return RedirectToAction("ForgotPasswordConfirmation", "Account");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		[AllowAnonymous]
		public virtual ActionResult ForgotPasswordConfirmation()
		{
			return View();
		}

		[AllowAnonymous]
		public virtual ActionResult ResetPassword(string code)
		{
			return code == null ? View(MVC.Shared.Views.Error) : View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _accountService.ResetPasswordAsync(UserManager, model);
			if (result.Succeeded)
			{
				return RedirectToAction(MVC.Account.ActionNames.ResetPasswordConfirmation, MVC.Account.Name);
			}
			AddErrors(result);
			return View();
		}

		[AllowAnonymous]
		public virtual ActionResult ResetPasswordConfirmation()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public virtual ActionResult ExternalLogin(string provider, string returnUrl)
		{
			// Request a redirect to the external login provider
			return new ChallengeResult(provider, Url.Action(MVC.Account.ActionNames.ExternalLoginCallback, MVC.Account.Name, new { ReturnUrl = returnUrl }));
		}

		[AllowAnonymous]
		public virtual async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
		{
			var model = await _accountService.BuildSendCodeViewModelAsync(UserManager, SignInManager, returnUrl, rememberMe);
			if(model == null)
			{
				return View(MVC.Shared.Views.Error);
			}
			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> SendCode(SendCodeViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			// Generate the token and send it
			if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
			{
				return View(MVC.Shared.Views.Error);
			}
			return RedirectToAction(MVC.Account.ActionNames.VerifyCode, new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
		}

		[AllowAnonymous]
		public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl)
		{
			var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
			if (loginInfo == null)
			{
				return RedirectToAction(MVC.Account.ActionNames.Login);
			}

			// Sign in the user with this external login provider if the user already has a login
			var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
			switch (result)
			{
				case SignInStatus.Success:
					return RedirectToLocal(returnUrl);
				case SignInStatus.LockedOut:
					return View(MVC.Shared.Views.Lockout);
				case SignInStatus.RequiresVerification:
					return RedirectToAction(MVC.Account.ActionNames.SendCode, new { ReturnUrl = returnUrl, RememberMe = false });
				case SignInStatus.Failure:
				default:
					// If the user does not have an account, then prompt the user to create an account
					ViewBag.ReturnUrl = returnUrl;
					ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
					return View(MVC.Account.Views.ExternalLoginConfirmation, new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
			}
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction(MVC.Manage.ActionNames.Index, MVC.Manage.Name);
			}

			if (ModelState.IsValid)
			{
				var result = await _accountService.ConfirmExternalLoginAsync(AuthenticationManager, UserManager, SignInManager, model);
				if (result == null)
				{
					return View(MVC.Account.Views.ExternalLoginFailure);
				}
				if (result.Succeeded)
				{
					return RedirectToLocal(returnUrl);
				}
				AddErrors(result);
			}

			ViewBag.ReturnUrl = returnUrl;
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult LogOut()
		{
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
		}

		[AllowAnonymous]
		public virtual ActionResult ExternalLoginFailure()
		{
			return View();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_signInManager != null)
				{
					_signInManager.Dispose();
					_signInManager = null;
				}
			}

			base.Dispose(disposing);
		}

		#region Helpers

		// Used for XSRF protection when adding external logins
		private const string XsrfKey = "XsrfId";

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

		private ActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
		}

		internal class ChallengeResult : HttpUnauthorizedResult
		{
			public ChallengeResult(string provider, string redirectUri)
				: this(provider, redirectUri, null)
			{
			}

			public ChallengeResult(string provider, string redirectUri, string userId)
			{
				LoginProvider = provider;
				RedirectUri = redirectUri;
				UserId = userId;
			}

			public string LoginProvider { get; set; }
			public string RedirectUri { get; set; }
			public string UserId { get; set; }

			public override void ExecuteResult(ControllerContext context)
			{
				var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
				if (UserId != null)
				{
					properties.Dictionary[XsrfKey] = UserId;
				}
				context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
			}
		}

		#endregion
	}
}
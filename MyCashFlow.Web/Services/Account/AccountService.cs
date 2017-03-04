﻿using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Repositories.Repository;
using MyCashFlow.Web.ViewModels.Account;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace MyCashFlow.Web.Services.Account
{
	public class AccountService : IAccountService
	{
		private readonly IRepository<Country> _countryRepository;

		public AccountService(IRepository<Country> countryRepository)
		{
			if(countryRepository == null)
			{
				throw new ArgumentNullException(nameof(countryRepository));
			}

			_countryRepository = countryRepository;
		}

		public RegisterViewModel BuildRegisterViewModel()
		{
			var model = new RegisterViewModel
			{
				Countries = GetCountries()
			};
			return model;
		}

		public IEnumerable<Country> GetCountries()
		{
			var countries = _countryRepository.Get();
			return countries;
		}

		public VerifyCodeViewModel BuildVerifyCodeViewModel(
			string provider,
			string returnUrl,
			bool rememberMe)
		{
			var result = new VerifyCodeViewModel
			{
				Provider = provider,
				ReturnUrl = returnUrl,
				RememberMe = rememberMe
			};
			return result;
		}

		public async Task<IdentityResult> RegisterUserAsync(
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			RegisterViewModel model)
		{
			// TODO: use automapper
			var user = new User
			{
				UserName = model.UserName,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				CountryID = model.CountryID,
				Gender = model.Gender,
				FirstName = model.FirstName,
				MiddleName = model.MiddleName,
				LastName = model.LastName
			};

			var result = await userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				await signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

				// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
				// Send an email with this link
				// string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
				// var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
				// await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
			}

			return result;
		}

		public async Task<IdentityResult> ResetPasswordAsync(
			UserManager<User> userManager,
			ResetPasswordViewModel model)
		{
			var user = await userManager.FindByNameAsync(model.Email);
			if (user == null)
			{
				// Don't reveal that the user does not exist
				return IdentityResult.Success;
			}

			var result = await userManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
			return result;
		}

		public async Task<SendCodeViewModel> BuildSendCodeViewModelAsync(
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			string returnUrl,
			bool rememberMe)
		{
			var userId = await signInManager.GetVerifiedUserIdAsync();
			if (userId == null)
			{
				return null;
			}
			var userFactors = await userManager.GetValidTwoFactorProvidersAsync(userId);
			var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();

			var result = new SendCodeViewModel
			{
				Providers = factorOptions,
				ReturnUrl = returnUrl,
				RememberMe = rememberMe
			};
			return result;
		}

		public async Task<IdentityResult> ConfirmExternalLoginAsync(
			IAuthenticationManager authenticationManager,
			UserManager<User> userManager,
			SignInManager<User, string> signInManager,
			ExternalLoginConfirmationViewModel model)
		{
			// Get the information about the user from the external login provider
			var info = await authenticationManager.GetExternalLoginInfoAsync();
			if (info == null)
			{
				return null;
			}

			var user = new User
			{
				UserName = model.Email,
				Email = model.Email
			};
			var result = await userManager.CreateAsync(user);
			if (result.Succeeded)
			{
				result = await userManager.AddLoginAsync(user.Id, info.Login);
				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
					return IdentityResult.Success;
				}
			}
			return result;
		}
	}
}
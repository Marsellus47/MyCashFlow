using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Identity.Context;
using MyCashFlow.Identity.Services;
using MyCashFlow.Identity.Stores;
using System;

namespace MyCashFlow.Identity.Managers
{
	public class ApplicationUserManager : UserManager<User, int>
	{
		public ApplicationUserManager(IUserStore<User, int> store)
			: base(store)
		{ }

		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			var manager = new ApplicationUserManager(new CustomUserStore(context.Get<ApplicationDbContext>()));
			// Configure validation logic for usernames
			manager.UserValidator = new UserValidator<User, int>(manager)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true
			};

			// Configure validation logic for passwords
			manager.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 6,
				RequireNonLetterOrDigit = true,
				RequireDigit = true,
				RequireLowercase = true,
				RequireUppercase = true,
			};

			// Configure user lockout defaults
			manager.UserLockoutEnabledByDefault = true;
			manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
			manager.MaxFailedAccessAttemptsBeforeLockout = 5;

			// Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
			// You can write your own provider and plug it in here.
			manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User, int>
			{
				MessageFormat = "Your security code is {0}"
			});
			manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User, int>
			{
				Subject = "Security Code",
				BodyFormat = "Your security code is {0}"
			});
			manager.EmailService = new EmailService();
			manager.SmsService = new SmsService();
			var dataProtectionProvider = options.DataProtectionProvider;
			if (dataProtectionProvider != null)
			{
				manager.UserTokenProvider =
					new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity"));
			}
			return manager;
		}
	}
}

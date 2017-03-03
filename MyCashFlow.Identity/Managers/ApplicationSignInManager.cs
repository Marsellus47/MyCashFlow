using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Identity.Extensions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyCashFlow.Identity.Managers
{
	public class ApplicationSignInManager : SignInManager<User, string>
	{
		public ApplicationSignInManager(
			UserManager<User, string> userManager,
			IAuthenticationManager authenticationManager)
			: base(userManager, authenticationManager)
		{
		}

		public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
		{
			return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
		}

		public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
		{
			return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
		}
	}
}

using Microsoft.AspNet.Identity;
using MyCashFlow.Domains.DataObject;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyCashFlow.Identity.Extensions
{
	public static class UserExtensions
	{
		public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(this User user, UserManager<User> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}
}

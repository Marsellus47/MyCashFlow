using Microsoft.AspNet.Identity.EntityFramework;
using MyCashFlow.Identity.Models;

namespace MyCashFlow.Identity.Context
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{ }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}

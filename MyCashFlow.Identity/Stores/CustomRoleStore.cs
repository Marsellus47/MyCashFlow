using Microsoft.AspNet.Identity.EntityFramework;
using MyCashFlow.Domains.Identity;
using MyCashFlow.Identity.Context;

namespace MyCashFlow.Identity.Stores
{
	public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
	{
		public CustomRoleStore(ApplicationDbContext context)
			: base(context)
		{
		}
	}
}

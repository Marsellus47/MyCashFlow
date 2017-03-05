using Microsoft.AspNet.Identity.EntityFramework;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Domains.Identity;
using MyCashFlow.Identity.Context;

namespace MyCashFlow.Identity.Stores
{
	public class CustomUserStore : UserStore<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
	{
		public CustomUserStore(ApplicationDbContext context)
			: base(context)
		{
		}
	}
}

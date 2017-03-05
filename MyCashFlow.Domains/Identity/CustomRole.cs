using Microsoft.AspNet.Identity.EntityFramework;

namespace MyCashFlow.Domains.Identity
{
	public class CustomRole : IdentityRole<int, CustomUserRole>
	{
		public CustomRole() { }
		public CustomRole(string name) { Name = name; }
	}
}

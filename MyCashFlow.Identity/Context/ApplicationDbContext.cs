using Microsoft.AspNet.Identity.EntityFramework;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Identity.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace MyCashFlow.Identity.Context
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(string nameOrConnectionString)
			: base(nameOrConnectionString, throwIfV1Schema: false)
		{ }
		
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Country> Countries { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<User>().ToTable("User", "Configuration");

			modelBuilder.Entity<IdentityUserRole>().HasKey(userRole => new { userRole.RoleId, userRole.UserId });
			modelBuilder.Entity<IdentityUserLogin>().HasKey(login => login.UserId);
			modelBuilder.Entity<IdentityRole>().HasKey(role => role.Id);
		}
	}
}

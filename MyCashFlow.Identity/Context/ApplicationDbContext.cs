using Microsoft.AspNet.Identity.EntityFramework;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Domains.Identity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace MyCashFlow.Identity.Context
{
	public class ApplicationDbContext : IdentityDbContext<
		User,
		CustomRole,
		int,
		CustomUserLogin,
		CustomUserRole,
		CustomUserClaim>
	{
		public ApplicationDbContext(string nameOrConnectionString)
			: base(nameOrConnectionString)
		{ }
		
		public DbSet<Country> Countries { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<TransactionType> TransactionTypes { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<PaymentMethod> PaymentMethods { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<User>()
				.ToTable("User", "Configuration");

			modelBuilder.Entity<IdentityUserRole>().HasKey(userRole => new { userRole.RoleId, userRole.UserId });
			modelBuilder.Entity<IdentityUserLogin>().HasKey(login => login.UserId);
			modelBuilder.Entity<IdentityRole>().HasKey(role => role.Id);
		}
	}
}

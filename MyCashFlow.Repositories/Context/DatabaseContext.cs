using MyCashFlow.Domains.DataObject;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace MyCashFlow.Repositories.Context
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Country> Countries { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}

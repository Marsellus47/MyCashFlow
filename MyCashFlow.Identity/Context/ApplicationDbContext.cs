using Microsoft.AspNet.Identity.EntityFramework;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Domains.Identity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System;

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
		public DbSet<Currency> Currencies { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<User>()
				.ToTable("User", "Configuration");

			/*modelBuilder.Entity<IdentityUserRole>().HasKey(userRole => new { userRole.RoleId, userRole.UserId });
			modelBuilder.Entity<IdentityUserLogin>().HasKey(login => login.UserId);
			modelBuilder.Entity<IdentityRole>().HasKey(role => role.Id);*/
		}

		public TEntity GetOriginal<TEntity>(TEntity updatedEntity)
			where TEntity : class
		{
			Func<DbPropertyValues, Type, object> getOriginal = null;
			getOriginal = (originalValues, type) =>
			{
				object original = Activator.CreateInstance(type, true);
				foreach (var ptyName in originalValues.PropertyNames)
				{
					var property = type.GetProperty(ptyName);
					object value = originalValues[ptyName];
					if (value is DbPropertyValues) //nested complex object
					{
						property.SetValue(original, getOriginal(value as DbPropertyValues, property.PropertyType));
					}
					else
					{
						property.SetValue(original, value);
					}
				}
				return original;
			};
			return (TEntity)getOriginal(Entry(updatedEntity).GetDatabaseValues(), typeof(TEntity));
		}
	}
}

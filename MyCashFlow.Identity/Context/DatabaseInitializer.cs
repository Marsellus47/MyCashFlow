using MyCashFlow.Domains.DataObject;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyCashFlow.Identity.Context
{
	public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			var countries = new List<Country>
			{
				new Country { Name = "Slovakia", ISOCode2 = "SK", ISOCode3 = "SVK", TelephoneCountryCode = 421 },
				new Country { Name = "Czech Republic", ISOCode2 = "CZ", ISOCode3 = "CZE", TelephoneCountryCode = 420 }
			};

			countries.ForEach(c => context.Countries.Add(c));
			context.SaveChanges();
		}
	}
}

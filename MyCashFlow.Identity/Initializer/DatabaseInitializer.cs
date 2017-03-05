using MyCashFlow.Domains.DataObject;
using MyCashFlow.Identity.Context;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyCashFlow.Identity.Initializer
{
	public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			AddCountries(context);
			AddPaymentTypes(context);
			AddTransactionTypes(context);
		}

		#region Helpers

		private static void AddCountries(ApplicationDbContext context)
		{
			var countries = new List<Country>
			{
				new Country { Name = "Slovakia", ISOCode2 = "SK", ISOCode3 = "SVK", TelephoneCountryCode = 421 },
				new Country { Name = "Czech Republic", ISOCode2 = "CZ", ISOCode3 = "CZE", TelephoneCountryCode = 420 }
			};

			countries.ForEach(c => context.Countries.Add(c));
			context.SaveChanges();
		}

		private static void AddPaymentTypes(ApplicationDbContext context)
		{
			var paymentTypes = new List<PaymentType>
			{
				new PaymentType { Name = "Cash" },
				new PaymentType { Name = "Credit card" },
				new PaymentType { Name = "Cheque" },
				new PaymentType { Name = "Invoice" }
			};

			paymentTypes.ForEach(pt => context.PaymentTypes.Add(pt));
			context.SaveChanges();
		}

		private static void AddTransactionTypes(ApplicationDbContext context)
		{
			var transactionTypes = new List<TransactionType>
			{
				new TransactionType { Name = "Transportation" },
				new TransactionType { Name = "Bank" },
				new TransactionType { Name = "Insurance" },
				new TransactionType { Name = "Living" },
				new TransactionType { Name = "Household" },
				new TransactionType { Name = "Travel & Leisure" },
				new TransactionType { Name = "Salary" },
				new TransactionType { Name = "Groceries" },
				new TransactionType { Name = "Gift" },
				new TransactionType { Name = "Savings" },
				new TransactionType { Name = "Other" }
			};

			transactionTypes.ForEach(tt => context.TransactionTypes.Add(tt));
			context.SaveChanges();
		}

		#endregion
	}
}

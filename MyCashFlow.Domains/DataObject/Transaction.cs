using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCashFlow.Domains.DataObject
{
	[Table("Transaction", Schema = "Configuration")]
	public class Transaction
	{
		#region Primary key

		public int TransactionID { get; set; }

		#endregion

		#region Standard fields

		public DateTime Date { get; set; }
		public decimal Amount { get; set; }
		public string Note { get; set; }

		#endregion

		#region Foreign keys

		public int? ProjectID { get; set; }
		public int TransactionTypeID { get; set; }
		public int? PaymentTypeID { get; set; }


		public virtual Project Project { get; set; }
		public virtual TransactionType TransactionType { get; set; }
		public virtual PaymentType PaymentType { get; set; }

		#endregion
	}
}

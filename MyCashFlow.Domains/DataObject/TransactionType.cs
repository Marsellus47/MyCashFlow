using System.ComponentModel.DataAnnotations.Schema;

namespace MyCashFlow.Domains.DataObject
{
	[Table("TransactionType", Schema = "Configuration")]
	public class TransactionType
	{
		#region Primary key

		public int TransactionTypeID { get; set; }

		#endregion

		#region Standard fields

		public string Name { get; set; }

		#endregion

		#region Foreign keys

		public int? CreatorID { get; set; }

		public virtual User Creator { get; set; }

		#endregion
	}
}

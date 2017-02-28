using System.ComponentModel.DataAnnotations.Schema;

namespace MyCashFlow.Domains.DataObject
{
	[Table("PaymentType", Schema = "Configuration")]
	public class PaymentType
	{
		#region Primary key

		public int PaymentTypeID { get; set; }

		#endregion

		#region Standard fields

		public string Name { get; set; }

		#endregion

		#region Foreign keys

		public int CreatorID { get; set; }

		public virtual User Creator { get; set; }

		#endregion
	}
}

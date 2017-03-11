using System.ComponentModel.DataAnnotations.Schema;

namespace MyCashFlow.Domains.DataObject
{
	[Table("PaymentMethod", Schema = "Configuration")]
	public class PaymentMethod
	{
		#region Primary key

		public int PaymentMethodID { get; set; }

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

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Domains.DataObject
{
	[Table("Currency", Schema = "Configuration")]
	public class Currency
	{
		#region Primary key

		public int CurrencyID { get; set; }

		#endregion

		#region Standard fields

		[Index(IsUnique = true)]
		[StringLength(128)]
		public string Name { get; set; }

		[StringLength(3)]
		public string ISOCode { get; set; }

		[StringLength(5)]
		public string Sign { get; set; }

		public string FractionalUnit { get; set; }


		#endregion

		#region Foreign keys

		public int? CreatorID { get; set; }

		public virtual User Creator { get; set; }

		#endregion
	}
}

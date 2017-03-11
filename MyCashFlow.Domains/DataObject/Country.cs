using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCashFlow.Domains.DataObject
{
	[Table("Country", Schema = "System")]
	public class Country
	{
		#region Primary key

		public short ID { get; set; }

		#endregion

		#region Standard fields

		[Index(IsUnique = true)]
		[StringLength(128)]
		public string Name { get; set; }

		[Column(TypeName = "char")]
		[StringLength(2)]
		[Display(Name = "Short ISO code")]
		public string ISOCode2 { get; set; }

		[Column(TypeName = "char")]
		[StringLength(3)]
		[Display(Name = "Long ISO code")]
		public string ISOCode3 { get; set; }

		[Display(Name = "Telephone country code")]
		public int? TelephoneCountryCode { get; set; }

		#endregion
	}
}

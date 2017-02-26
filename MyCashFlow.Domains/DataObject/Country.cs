using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCashFlow.Domains.DataObject
{
	[Table("Country", Schema = "System")]
	public class Country
	{
		#region Primary keys

		public short ID { get; set; }

		#endregion

		#region Standard fields

		[Index(IsUnique = true)]
		public string Name { get; set; }

		[Column(TypeName = "char")]
		[StringLength(2)]
		[Display(Name = "ISO code 2")]
		public string ISOCode2 { get; set; }

		[Column(TypeName = "char")]
		[StringLength(3)]
		[Display(Name = "ISO code 3")]
		public string ISOCode3 { get; set; }

		[Display(Name = "Telephone country code")]
		public short TelephoneCountryCode { get; set; }

		[ScaffoldColumn(false)]
		public bool Active { get; set; } = true;

		#endregion
	}
}

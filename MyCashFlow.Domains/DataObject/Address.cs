using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCashFlow.Domains.DataObject
{
	[Table("Address", Schema = "Configuration")]
	public class Address
	{
		#region Primary key

		public int ID { get; set; }

		#endregion

		#region Standard fields

		[Display(Name = "Address line 1")]
		public string Line1 { get; set; }

		[Display(Name = "Address line 2")]
		public string Line2 { get; set; }

		public string City { get; set; }

		public string Zip { get; set; }

		public string District { get; set; }

		#endregion
	}
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCashFlow.Domains.DataObject
{
	[Table("Contact", Schema = "Configuration")]
	public class Contact
	{
		#region Primary key

		public int ID { get; set; }

		#endregion

		#region Standard fields

		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }

		#endregion
	}
}

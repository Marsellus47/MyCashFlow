using MyCashFlow.Domains.Artificial;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCashFlow.Domains.DataObject
{
	[Table("User", Schema = "Configuration")]
	public class User
	{
		#region Primary keys

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		#endregion

		#region Standard fields

		public string Login { get; set; }

		public string Password { get; set; }

		[Required]
		[Index(IsUnique = true)]
		[StringLength(128)]
		[Display(Name = "Display name")]
		public string DisplayName { get; set; }
		
		public Gender Gender { get; set; }

		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Display(Name = "Middle name")]
		public string MiddleName { get; set; }

		[Display(Name = "Last name")]
		public string LastName { get; set; }

		[ScaffoldColumn(false)]
		public bool Active { get; set; } = true;

		#endregion

		#region Foreign keys

		[Display(Name = "Country")]
		public short CountryID { get; set; }

		public int? AddressID { get; set; }

		public int? ContactID { get; set; }

		public virtual Country Country { get; set; }
		public virtual Address Address { get; set; }
		public virtual Contact Contact { get; set; }

		#endregion
	}
}

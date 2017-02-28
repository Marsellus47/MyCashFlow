using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyCashFlow.Domains.DataObject
{
	[Table("Project", Schema = "Configuration")]
	public class Project
	{
		#region Primary key

		public int ProjectID { get; set; }

		#endregion

		#region Standard fields

		public string Name { get; set; }

		[Display(Name = "Valid from")]
		public DateTime? ValidFrom { get; set; }

		[Display(Name = "Valid till")]
		public DateTime? ValidTill { get; set; }

		[Display(Name = "Sequence number")]
		public int SequenceNumber { get; set; }

		#endregion

		#region Foreign keys

		public int CreatorID { get; set; }

		public virtual User Creator { get; set; }

		#endregion
	}
}

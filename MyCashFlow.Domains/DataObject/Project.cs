using System.Collections.Generic;
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

		[Required]
		public string Name { get; set; }
		public DateTime? ValidFrom { get; set; }
		public DateTime? ValidTill { get; set; }
		public decimal? Budget { get; set; }
		public decimal ActualValue { get; set; }
		public int SequenceNumber { get; set; }

		#endregion

		#region Foreign keys

		public int CreatorID { get; set; }

		public virtual User Creator { get; set; }
		public virtual List<Transaction> Transactions { get; set; }

		#endregion
	}
}

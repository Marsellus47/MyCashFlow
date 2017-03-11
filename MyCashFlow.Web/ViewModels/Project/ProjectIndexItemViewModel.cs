using MyCashFlow.Web.Infrastructure.Automapper;
using Rsx = MyCashFlow.Resources.Localization.Views.Project._Shared;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyCashFlow.Web.ViewModels.Project
{
	public class ProjectIndexItemViewModel : IMapFrom<Domains.DataObject.Project>
	{
		[Key]
		public int ProjectID { get; set; }

		[Display(Name = nameof(Rsx.Field_Name), ResourceType = typeof(Rsx))]
		public string Name { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = nameof(Rsx.Field_ValidFrom), ResourceType = typeof(Rsx))]
		public DateTime? ValidFrom { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = nameof(Rsx.Field_ValidTill), ResourceType = typeof(Rsx))]
		public DateTime? ValidTill { get; set; }

		[Display(Name = nameof(Rsx.Field_SequenceNumber), ResourceType = typeof(Rsx))]
		public int SequenceNumber { get; set; }
	}
}
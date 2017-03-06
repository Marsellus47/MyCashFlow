using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyCashFlow.Web.ViewModels.Project
{
	public class ProjectEditViewModel : CreatorBaseViewModel, IMapFrom<Domains.DataObject.Project>, IMapTo<Domains.DataObject.Project>
	{
		public ProjectEditViewModel()
			: base(title: Rsx.Project._Shared.Title,
				  header: string.Format(Rsx.Shared.Edit.Header, Rsx.Project._Shared.Title.ToLower()))
		{ }

		public int ProjectID { get; set; }

		[Required]
		[Display(Name = nameof(Rsx.Project._Shared.Field_Name), ResourceType = typeof(Rsx.Project._Shared))]
		public string Name { get; set; }

		[Display(Name = nameof(Rsx.Project._Shared.Field_ValidFrom), ResourceType = typeof(Rsx.Project._Shared))]
		public DateTime? ValidFrom { get; set; }

		[Display(Name = nameof(Rsx.Project._Shared.Field_ValidTill), ResourceType = typeof(Rsx.Project._Shared))]
		public DateTime? ValidTill { get; set; }
	}
}
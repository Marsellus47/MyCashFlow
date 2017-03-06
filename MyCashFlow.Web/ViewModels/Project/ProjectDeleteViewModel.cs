using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.Project
{
	public class ProjectDeleteViewModel : BaseViewModel, IMapFrom<Domains.DataObject.Project>
	{
		public ProjectDeleteViewModel()
			: base(title: Rsx.Project._Shared.Title,
				  header: string.Format(Rsx.Shared.Delete.Header, Rsx.Project._Shared.Title.ToLower()))
		{ }

		public int ProjectID { get; set; }

		[Required]
		[Display(Name = nameof(Rsx.Project.Delete.Field_Name), ResourceType = typeof(Rsx.Project._Shared))]
		public string Name { get; set; }

		public string Message { get; set; }
		
		public string DeleteIncludingTransactionsButtonLabel { get; set; }
		
		public string DeleteProjectOnlyButtonLabel { get; set; }
	}
}
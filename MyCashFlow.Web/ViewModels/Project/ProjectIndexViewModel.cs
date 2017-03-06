using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.Collections.Generic;

namespace MyCashFlow.Web.ViewModels.Project
{
	public class ProjectIndexViewModel : BaseViewModel
	{
		public ProjectIndexViewModel()
			: base(title: Rsx.Project._Shared.Title,
				  header: string.Format(Rsx.Shared.Index.Header, Rsx.Project._Shared.Title.ToLower() + "s")) { }

		public IList<ProjectIndexItemViewModel> Items { get; set; }
	}
}
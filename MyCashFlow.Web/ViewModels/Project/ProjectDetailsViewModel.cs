using MyCashFlow.Web.ViewModels.Shared;
using MyCashFlow.Web.ViewModels.Transaction;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.Collections.Generic;

namespace MyCashFlow.Web.ViewModels.Project
{
	public class ProjectDetailsViewModel : BaseViewModel
	{
		public ProjectDetailsViewModel()
			: base(title: Rsx.Transaction._Shared.Title,
				  header: string.Format(Rsx.Shared.Details.Header, Rsx.Project._Shared.Title))
		{ }

		public IList<TransactionIndexItemViewModel> Items { get; set; }
		public int ProjectID { get; set; }
	}
}
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.Collections.Generic;

namespace MyCashFlow.Web.ViewModels.Transaction
{
	public class TransactionIndexViewModel : BaseViewModel
	{
		public TransactionIndexViewModel()
			: base(title: Rsx.Transaction._Shared.Title,
				  header: string.Format(Rsx.Shared.Index.Header, Rsx.Transaction._Shared.Title.ToLower() + "s")) { }

		public IList<TransactionIndexItemViewModel> Items { get; set; }
	}
}
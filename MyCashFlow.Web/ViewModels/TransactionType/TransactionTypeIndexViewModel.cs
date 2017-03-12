using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.Collections.Generic;

namespace MyCashFlow.Web.ViewModels.TransactionType
{
	public class TransactionTypeIndexViewModel : BaseViewModel
	{
		public TransactionTypeIndexViewModel()
			: base(title: Rsx.TransactionType._Shared.Title,
				  header: string.Format(Rsx.Shared.Index.Header, Rsx.TransactionType._Shared.Title.ToLower() + "s")) { }

		public IList<TransactionTypeIndexItemViewModel> Items { get; set; }
	}
}
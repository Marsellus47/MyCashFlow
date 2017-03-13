using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.Collections.Generic;

namespace MyCashFlow.Web.ViewModels.PaymentMethod
{
	public class PaymentMethodIndexViewModel : BaseViewModel
	{
		public PaymentMethodIndexViewModel()
			: base(title: Rsx.PaymentMethod._Shared.Title,
				  header: string.Format(Rsx.Shared.Index.Header, Rsx.PaymentMethod._Shared.Title.ToLower() + "s"))
		{ }

		public IList<PaymentMethodIndexItemViewModel> Items { get; set; }
	}
}
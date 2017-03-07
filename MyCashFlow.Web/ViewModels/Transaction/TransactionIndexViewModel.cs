using System.Collections.Generic;

namespace MyCashFlow.Web.ViewModels.Transaction
{
	public class TransactionIndexViewModel
	{
		public IEnumerable<TransactionIndexItemViewModel> Items { get; set; }
	}
}
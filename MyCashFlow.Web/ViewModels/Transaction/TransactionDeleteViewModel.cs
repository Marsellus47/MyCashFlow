using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyCashFlow.Web.ViewModels.Transaction
{
	public class TransactionDeleteViewModel :
		BaseViewModel,
		IMapFrom<Domains.DataObject.Transaction>
	{
		public TransactionDeleteViewModel()
			: base(title: Rsx.Transaction._Shared.Title,
				  header: string.Format(Rsx.Shared.Delete.Header, Rsx.Transaction._Shared.Title.ToLower()))
		{ }

		[ScaffoldColumn(false)]
		public int TransactionID { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = nameof(Rsx.Transaction._Shared.Field_Date), ResourceType = typeof(Rsx.Transaction._Shared))]
		public DateTime Date { get; set; }

		[Display(Name = nameof(Rsx.Transaction._Shared.Field_Amount), ResourceType = typeof(Rsx.Transaction._Shared))]
		public decimal Amount { get; set; }

		[Display(Name = nameof(Rsx.Transaction._Shared.Field_Income), ResourceType = typeof(Rsx.Transaction._Shared))]
		public bool Income { get; set; }
	}
}
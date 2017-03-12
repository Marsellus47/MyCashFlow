using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyCashFlow.Web.ViewModels.Transaction
{
	public class TransactionDetailsViewModel :
		CreatorBaseViewModel,
		IMapFrom<Domains.DataObject.Transaction>
	{
		public TransactionDetailsViewModel()
			: base(title: Rsx.Transaction._Shared.Title,
				  header: string.Format(Rsx.Shared.Details.Header, Rsx.Transaction._Shared.Title))
		{ }

		[ScaffoldColumn(false)]
		public int TransactionID { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = nameof(Rsx.Transaction._Shared.Field_Date), ResourceType = typeof(Rsx.Transaction._Shared))]
		public DateTime Date { get; set; }

		[Display(Name = nameof(Rsx.Transaction._Shared.Field_Amount), ResourceType = typeof(Rsx.Transaction._Shared))]
		public decimal Amount { get; set; }

		[DataType(DataType.MultilineText)]
		[Display(Name = nameof(Rsx.Transaction._Shared.Field_Note), ResourceType = typeof(Rsx.Transaction._Shared))]
		public string Note { get; set; }

		[Display(Name = nameof(Rsx.Transaction._Shared.Field_Income), ResourceType = typeof(Rsx.Transaction._Shared))]
		public bool Income { get; set; }

		[Display(Name = nameof(Rsx.Transaction._Shared.Field_Project), ResourceType = typeof(Rsx.Transaction._Shared))]
		public string ProjectName { get; set; }

		[Display(Name = nameof(Rsx.Transaction._Shared.Field_TransactionType), ResourceType = typeof(Rsx.Transaction._Shared))]
		public string TransactionTypeName { get; set; }

		[Display(Name = nameof(Rsx.Transaction._Shared.Field_PaymentMethod), ResourceType = typeof(Rsx.Transaction._Shared))]
		public string PaymentMethodName { get; set; }
	}
}
using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace MyCashFlow.Web.ViewModels.Transaction
{
	public class TransactionCreateViewModel : CreatorBaseViewModel, IMapTo<Domains.DataObject.Transaction>
	{
		public TransactionCreateViewModel()
			: base(title: Rsx.Transaction._Shared.Title,
				  header: string.Format(Rsx.Shared.Create.Header, Rsx.Transaction._Shared.Title.ToLower()))
		{ }

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

		[ReadOnly(true)]
		[Display(Name = nameof(Rsx.Transaction.Create.Field_Project), ResourceType = typeof(Rsx.Transaction.Create))]
		public int? ProjectID { get; set; }
		public IEnumerable<Domains.DataObject.Project> Projects { get; set; }

		[Display(Name = nameof(Rsx.Transaction.Create.Field_TransactionType), ResourceType = typeof(Rsx.Transaction.Create))]
		public int TransactionTypeID { get; set; }
		public IEnumerable<Domains.DataObject.TransactionType> TransactionTypes { get; set; }

		[Display(Name = nameof(Rsx.Transaction.Create.Field_PaymentType), ResourceType = typeof(Rsx.Transaction.Create))]
		public int? PaymentTypeID { get; set; }
		public IEnumerable<Domains.DataObject.PaymentType> PaymentTypes { get; set; }
	}
}
using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.TransactionType
{
	public class TransactionTypeCreateViewModel :
		CreatorBaseViewModel,
		IMapTo<Domains.DataObject.TransactionType>
	{
		public TransactionTypeCreateViewModel()
			: base(title: Rsx.TransactionType._Shared.Title,
				  header: string.Format(Rsx.Shared.Create.Header, Rsx.TransactionType._Shared.Title.ToLower()))
		{ }
		
		[Required]
		[Display(Name = nameof(Rsx.TransactionType._Shared.Field_Name), ResourceType = typeof(Rsx.TransactionType._Shared))]
		public string Name { get; set; }

		[ScaffoldColumn(false)]
		public string PreviousUrl { get; set; }
	}
}
using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.TransactionType
{
	public class TransactionTypeDeleteViewModel :
		BaseViewModel,
		IMapFrom<Domains.DataObject.TransactionType>
	{
		public TransactionTypeDeleteViewModel()
			: base(title: Rsx.TransactionType._Shared.Title,
				  header: string.Format(Rsx.Shared.Delete.Header, Rsx.TransactionType._Shared.Title.ToLower()))
		{ }

		[Key]
		[ScaffoldColumn(false)]
		public int TransactionTypeID { get; set; }
		
		[Display(Name = nameof(Rsx.TransactionType._Shared.Field_Name), ResourceType = typeof(Rsx.TransactionType._Shared))]
		public string Name { get; set; }
	}
}
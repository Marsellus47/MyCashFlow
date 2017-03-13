using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.PaymentMethod
{
	public class PaymentMethodEditViewModel :
		CreatorBaseViewModel,
		IMapFrom<Domains.DataObject.PaymentMethod>,
		IMapTo<Domains.DataObject.PaymentMethod>
	{
		public PaymentMethodEditViewModel()
			: base(title: Rsx.PaymentMethod._Shared.Title,
				  header: string.Format(Rsx.Shared.Edit.Header, Rsx.PaymentMethod._Shared.Title.ToLower()))
		{ }

		[Key]
		[ScaffoldColumn(false)]
		public int PaymentMethodID { get; set; }

		[Required]
		[Display(Name = nameof(Rsx.PaymentMethod._Shared.Field_Name), ResourceType = typeof(Rsx.PaymentMethod._Shared))]
		public string Name { get; set; }
	}
}
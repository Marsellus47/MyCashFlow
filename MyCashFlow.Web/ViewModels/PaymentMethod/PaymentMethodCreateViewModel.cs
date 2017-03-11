using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.PaymentMethod
{
	public class PaymentMethodCreateViewModel :
		CreatorBaseViewModel,
		IMapTo<Domains.DataObject.PaymentMethod>
	{
		public PaymentMethodCreateViewModel()
			: base(title: Rsx.PaymentMethod._Shared.Title,
				  header: string.Format(Rsx.Shared.Create.Header, Rsx.PaymentMethod._Shared.Title.ToLower()))
		{ }

		[Required]
		[Display(Name = nameof(Rsx.PaymentMethod._Shared.Field_Name), ResourceType = typeof(Rsx.PaymentMethod._Shared))]
		public string Name { get; set; }

		[ScaffoldColumn(false)]
		public string PreviousUrl { get; set; }
	}
}
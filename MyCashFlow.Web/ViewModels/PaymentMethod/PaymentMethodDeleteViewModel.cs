using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.PaymentMethod
{
	public class PaymentMethodDeleteViewModel :
		BaseViewModel,
		IMapFrom<Domains.DataObject.PaymentMethod>
	{
		public PaymentMethodDeleteViewModel()
			: base(title: Rsx.PaymentMethod._Shared.Title,
				  header: string.Format(Rsx.Shared.Delete.Header, Rsx.PaymentMethod._Shared.Title.ToLower()))
		{ }

		[Key]
		[ScaffoldColumn(false)]
		public int PaymentMethodID { get; set; }

		[Display(Name = nameof(Rsx.PaymentMethod._Shared.Field_Name), ResourceType = typeof(Rsx.PaymentMethod._Shared))]
		public string Name { get; set; }
	}
}
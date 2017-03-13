using AutoMapper;
using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.PaymentMethod
{
	public class PaymentMethodDetailsViewModel :
		CreatorBaseViewModel,
		IHaveCustomMappings
	{
		public PaymentMethodDetailsViewModel()
			: base(title: Rsx.PaymentMethod._Shared.Title,
				  header: string.Format(Rsx.Shared.Details.Header, Rsx.PaymentMethod._Shared.Title))
		{ }

		[Key]
		[ScaffoldColumn(false)]
		public int PaymentMethodID { get; set; }

		[Required]
		[Display(Name = nameof(Rsx.PaymentMethod._Shared.Field_Name), ResourceType = typeof(Rsx.PaymentMethod._Shared))]
		public string Name { get; set; }

		[ScaffoldColumn(false)]
		public bool Private { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Domains.DataObject.PaymentMethod, PaymentMethodDetailsViewModel>()
				.ForMember(dest => dest.Private, opt => opt.MapFrom(src => src.CreatorID.HasValue));
		}
	}
}
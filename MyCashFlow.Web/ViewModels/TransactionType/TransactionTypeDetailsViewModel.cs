using AutoMapper;
using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.TransactionType
{
	public class TransactionTypeDetailsViewModel :
		CreatorBaseViewModel,
		IHaveCustomMappings
	{
		public TransactionTypeDetailsViewModel()
			: base(title: Rsx.TransactionType._Shared.Title,
				  header: string.Format(Rsx.Shared.Details.Header, Rsx.TransactionType._Shared.Title))
		{ }

		[Key]
		[ScaffoldColumn(false)]
		public int TransactionTypeID { get; set; }

		[Required]
		[Display(Name = nameof(Rsx.TransactionType._Shared.Field_Name), ResourceType = typeof(Rsx.TransactionType._Shared))]
		public string Name { get; set; }

		[ScaffoldColumn(false)]
		public bool Private { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Domains.DataObject.TransactionType, TransactionTypeDetailsViewModel>()
				.ForMember(dest => dest.Private, opt => opt.MapFrom(src => src.CreatorID.HasValue));
		}
	}
}
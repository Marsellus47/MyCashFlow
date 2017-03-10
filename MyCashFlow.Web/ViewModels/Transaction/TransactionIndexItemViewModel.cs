using AutoMapper;
using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyCashFlow.Web.ViewModels.Transaction
{
	public class TransactionIndexItemViewModel :
		BaseViewModel,
		IHaveCustomMappings
	{
		public TransactionIndexItemViewModel()
			: base(title: Rsx.Transaction._Shared.Title,
				  header: string.Format(Rsx.Shared.Index.Header, Rsx.Transaction._Shared.Title.ToLower() + "s")) { }

		[Key]
		public int TransactionID { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = nameof(Rsx.Transaction._Shared.Field_Date), ResourceType = typeof(Rsx.Transaction._Shared))]
		public DateTime Date { get; set; }

		[Display(Name = nameof(Rsx.Transaction._Shared.Field_Amount), ResourceType = typeof(Rsx.Transaction._Shared))]
		public decimal Amount { get; set; }

		public bool Income { get; set; }

		[Display(Name = nameof(Rsx.Transaction._Shared.Field_TransactionType), ResourceType = typeof(Rsx.Transaction._Shared))]
		public string TransactionType { get; set; }

		[Display(Name = nameof(Rsx.Transaction._Shared.Field_PaymentType), ResourceType = typeof(Rsx.Transaction._Shared))]
		public string PaymentType { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Domains.DataObject.Transaction, TransactionIndexItemViewModel>()
				.ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.Name))
				.ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.Name));
		}
	}
}
using MyCashFlow.Web.Infrastructure.Automapper;
using Rsx = MyCashFlow.Resources.Localization.Views.Project._Shared;
using System.ComponentModel.DataAnnotations;
using System;
using AutoMapper;
using System.Text;

namespace MyCashFlow.Web.ViewModels.Project
{
	public class ProjectIndexItemViewModel : IHaveCustomMappings
	{
		[Key]
		public int ProjectID { get; set; }

		[Display(Name = nameof(Rsx.Field_Name), ResourceType = typeof(Rsx))]
		public string Name { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = nameof(Rsx.Field_ValidFrom), ResourceType = typeof(Rsx))]
		public DateTime? ValidFrom { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = nameof(Rsx.Field_ValidTill), ResourceType = typeof(Rsx))]
		public DateTime? ValidTill { get; set; }

		[Display(Name = nameof(Rsx.Field_SequenceNumber), ResourceType = typeof(Rsx))]
		public int SequenceNumber { get; set; }

		[ScaffoldColumn(false)]
		[Display(Name = nameof(Rsx.Field_Progress), ResourceType = typeof(Rsx))]
		public decimal Progress { get; set; }

		public string ProgressCssClass
		{
			get
			{
				var @class = new StringBuilder("progress-bar progress-bar-");
				if(Progress <= 25)
				{
					@class.Append("danger");
				}
				else if (Progress <= 50)
				{
					@class.Append("warning");
				}
				else if (Progress <= 75)
				{
					@class.Append("info");
				}
				else
				{
					@class.Append("success");
				}
				return @class.ToString();
			}
		}

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Domains.DataObject.Project, ProjectIndexItemViewModel>()
				.ForMember(dest => dest.Progress, opt => opt.MapFrom(src =>
					(src.Budget ?? src.TargetValue ?? 0) == 0
					? 0
					: 100 * src.ActualValue / (src.Budget ?? src.TargetValue)));
		}
	}
}
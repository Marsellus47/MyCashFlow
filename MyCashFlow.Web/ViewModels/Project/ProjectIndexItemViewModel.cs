using AutoMapper;
using MyCashFlow.Web.Infrastructure.Automapper;
using Rsx = MyCashFlow.Resources.Localization.Views.Project;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System;

namespace MyCashFlow.Web.ViewModels.Project
{
	public class ProjectIndexItemViewModel : IHaveCustomMappings
	{
		[Key]
		public int ProjectID { get; set; }

		[Display(Name = nameof(Rsx._Shared.Field_Name), ResourceType = typeof(Rsx._Shared))]
		public string Name { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = nameof(Rsx._Shared.Field_ValidFrom), ResourceType = typeof(Rsx._Shared))]
		public DateTime? ValidFrom { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = nameof(Rsx._Shared.Field_ValidTill), ResourceType = typeof(Rsx._Shared))]
		public DateTime? ValidTill { get; set; }

		[Display(Name = nameof(Rsx._Shared.Field_SequenceNumber), ResourceType = typeof(Rsx._Shared))]
		public int SequenceNumber { get; set; }

		[ScaffoldColumn(false)]
		[Display(Name = nameof(Rsx.Index.Field_Progress), ResourceType = typeof(Rsx.Index))]
		public decimal Progress { get; set; }

		[ScaffoldColumn(false)]
		public string ProgressHint { get; set; }

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
				.ForMember(dest => dest.Progress, opt => opt.MapFrom(src => GetProgress(src)))
				.ForMember(dest => dest.ProgressHint, opt => opt.MapFrom(src =>
					src.Budget.HasValue
					? string.Format(Rsx.Index.Field_ProgressHint_Budget, GetProgress(src))
					: src.TargetValue.HasValue
						? string.Format(Rsx.Index.Field_ProgressHind_TargetValue, GetProgress(src))
						: string.Empty));
		}

		private decimal GetProgress(Domains.DataObject.Project project)
		{
			if(project.Budget.HasValue)
			{
				return 100 * project.ActualValue / project.Budget.Value;
			}
			else if(project.TargetValue.HasValue)
			{
				return 100 * project.ActualValue / project.TargetValue.Value;
			}
			return 0;
		}
	}
}
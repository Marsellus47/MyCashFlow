﻿using MyCashFlow.Web.Infrastructure.Automapper;
using MyCashFlow.Web.ViewModels.Shared;
using Rsx = MyCashFlow.Resources.Localization.Views.Project._Shared;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyCashFlow.Web.ViewModels.Project
{
	public class ProjectEditViewModel : CreatorBaseViewModel, IMapFrom<Domains.DataObject.Project>, IMapTo<Domains.DataObject.Project>
	{
		public int ProjectID { get; set; }

		[Required]
		[Display(Name = nameof(Rsx.Field_Name), ResourceType = typeof(Rsx))]
		public string Name { get; set; }

		[Display(Name = nameof(Rsx.Field_ValidFrom), ResourceType = typeof(Rsx))]
		public DateTime? ValidFrom { get; set; }

		[Display(Name = nameof(Rsx.Field_ValidTill), ResourceType = typeof(Rsx))]
		public DateTime? ValidTill { get; set; }
	}
}
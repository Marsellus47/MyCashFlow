using Rsx = MyCashFlow.Resources.Localization.Views.Shared._Shared;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.Shared
{
	public abstract class BaseViewModel
	{
		public BaseViewModel(string title, string header)
		{
			Title = title;
			Header = header;
			Create = Rsx.Label_Create;
			Edit = Rsx.Label_Edit;
			Details = Rsx.Label_Details;
			Delete = Rsx.Label_Delete;
			Back = Rsx.Label_Back;
		}

		[ScaffoldColumn(false)]
		public string Title { get; set; }

		[ScaffoldColumn(false)]
		public string Header { get; set; }

		[ScaffoldColumn(false)]
		public string Create { get; set; }

		[ScaffoldColumn(false)]
		public string Edit { get; set; }

		[ScaffoldColumn(false)]
		public string Details { get; set; }

		[ScaffoldColumn(false)]
		public string Delete { get; set; }

		[ScaffoldColumn(false)]
		public string Back { get; set; }
	}
}
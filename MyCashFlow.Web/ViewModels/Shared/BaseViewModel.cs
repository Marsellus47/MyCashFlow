using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.Shared
{
	public abstract class BaseViewModel
	{
		public BaseViewModel(string title, string header)
		{
			Title = title;
			Header = header;
		}

		[ScaffoldColumn(false)]
		public string Title { get; set; }

		[ScaffoldColumn(false)]
		public string Header { get; set; }
	}
}
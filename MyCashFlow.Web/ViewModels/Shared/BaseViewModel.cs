namespace MyCashFlow.Web.ViewModels.Shared
{
	public abstract class BaseViewModel
	{
		public BaseViewModel(string title, string header)
		{
			Title = title;
			Header = header;
		}

		public string Title { get; set; }
		public string Header { get; set; }
	}
}
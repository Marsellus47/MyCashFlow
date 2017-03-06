namespace MyCashFlow.Web.ViewModels.Shared
{
	public abstract class CreatorBaseViewModel : BaseViewModel
	{
		public CreatorBaseViewModel(string title, string header)
			: base(title, header) { }

		public int CreatorID { get; set; }
	}
}
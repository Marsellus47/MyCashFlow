using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.Shared
{
	public abstract class CreatorBaseViewModel : BaseViewModel
	{
		public CreatorBaseViewModel(string title, string header)
			: base(title, header) { }

		[ScaffoldColumn(false)]
		public int CreatorID { get; set; }
	}
}
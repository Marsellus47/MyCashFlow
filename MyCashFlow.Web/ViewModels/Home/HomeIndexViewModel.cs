using MyCashFlow.Web.ViewModels.Shared;
using MyCashFlow.Web.ViewModels.TransactionType;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.Home
{
	public class HomeIndexViewModel : BaseViewModel
	{
		public HomeIndexViewModel()
			: base(title: Rsx.Home._Shared.Title,
				  header: Rsx.Home.Index.Header)
		{ }

		[Display(Name = nameof(Rsx.Home.Index.Field_Projects), ResourceType = typeof(Rsx.Home.Index))]
		public int Projects { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Field_FinishedProjects), ResourceType = typeof(Rsx.Home.Index))]
		public int FinishedProjects { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Field_OpenProjects), ResourceType = typeof(Rsx.Home.Index))]
		public int OpenProjects { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Field_OpenFilledProjects), ResourceType = typeof(Rsx.Home.Index))]
		public int OpenFilledProjects { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Field_FinishedFilledProjects), ResourceType = typeof(Rsx.Home.Index))]
		public int FinishedFilledProjects { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Field_TotalFilledProjects), ResourceType = typeof(Rsx.Home.Index))]
		public int TotalFilledProjects { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Field_NonFilledProjects), ResourceType = typeof(Rsx.Home.Index))]
		public int NonFilledProjects { get; set; }

		public TransactionTypeIndexViewModel TransactionTypeIndexViewModel { get; set; }
	}
}
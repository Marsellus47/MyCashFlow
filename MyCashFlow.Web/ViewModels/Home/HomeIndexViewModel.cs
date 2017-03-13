using MyCashFlow.Web.ViewModels.PaymentMethod;
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
		{
			TargetValue = Rsx.Home.Index.Label_TargetValue;
			Budget = Rsx.Home.Index.Label_Budget;
		}

		[Display(Name = nameof(Rsx.Home.Index.Label_Projects), ResourceType = typeof(Rsx.Home.Index))]
		public int Projects { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Open), ResourceType = typeof(Rsx.Home.Index))]
		public int OpenProjects { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Spent), ResourceType = typeof(Rsx.Home.Index))]
		public int OpenProjectsWithSpentBudget { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Unspent), ResourceType = typeof(Rsx.Home.Index))]
		public int OpenProjectsWithUnspentBudget { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Unknown), ResourceType = typeof(Rsx.Home.Index))]
		public int OpenProjectsWithUnknownBudget { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Reached), ResourceType = typeof(Rsx.Home.Index))]
		public int OpenProjectsWithReachedTargetValue { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Missed), ResourceType = typeof(Rsx.Home.Index))]
		public int OpenProjectsWithMissedTargetValue { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Unknown), ResourceType = typeof(Rsx.Home.Index))]
		public int OpenProjectsWithUnknownTargetValue { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Finished), ResourceType = typeof(Rsx.Home.Index))]
		public int FinishedProjects { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Spent), ResourceType = typeof(Rsx.Home.Index))]
		public int FinishedProjectsWithSpentBudget { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Unspent), ResourceType = typeof(Rsx.Home.Index))]
		public int FinishedProjectsWithUnspentBudget { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Unknown), ResourceType = typeof(Rsx.Home.Index))]
		public int FinishedProjectsWithUnknownBudget { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Reached), ResourceType = typeof(Rsx.Home.Index))]
		public int FinishedProjectsWithReachedTargetValue { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Missed), ResourceType = typeof(Rsx.Home.Index))]
		public int FinishedProjectsWithMissedTargetValue { get; set; }

		[Display(Name = nameof(Rsx.Home.Index.Label_Unknown), ResourceType = typeof(Rsx.Home.Index))]
		public int FinishedProjectsWithUnknownTargetValue { get; set; }

		public string TargetValue { get; private set; }
		public string Budget { get; private set; }

		public TransactionTypeIndexViewModel TransactionTypeIndexViewModel { get; set; }
		public PaymentMethodIndexViewModel PaymentMethodIndexViewModel { get; set; }
	}
}
﻿using MyCashFlow.Repositories;
using MyCashFlow.Web.Infrastructure.ProjectsFilter;
using MyCashFlow.Web.Services.PaymentMethod;
using MyCashFlow.Web.Services.TransactionType;
using MyCashFlow.Web.ViewModels.Home;
using System.Linq;
using System;

namespace MyCashFlow.Web.Services.Home
{
	public class HomeService : IHomeService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITransactionTypeService _transactionTypeService;
		private readonly IPaymentMethodService _paymentMethodService;

		public HomeService(
			IUnitOfWork unitOfWork,
			ITransactionTypeService transactionTypeService,
			IPaymentMethodService paymentMethodService)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}
			if (transactionTypeService == null)
			{
				throw new ArgumentNullException(nameof(transactionTypeService));
			}
			if (paymentMethodService == null)
			{
				throw new ArgumentNullException(nameof(paymentMethodService));
			}

			_unitOfWork = unitOfWork;
			_transactionTypeService = transactionTypeService;
			_paymentMethodService = paymentMethodService;
		}

		public HomeIndexViewModel BuildHomeIndexViewModel(int userId)
		{
			var myProjects = _unitOfWork.ProjectRepository.Get(x => x.CreatorID == userId);

			var numberOfAllProjects = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.AllProjects))
				.Count();

			var numberOfOpenProjects = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.OpenProjects))
				.Count();

			var numberOfOpenProjectsWithSpentBudget = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.OpenProjectsWithSpentBudget))
				.Count();

			var numberOfOpenProjectsWithUnspentBudget = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.OpenProjectsWithUnspentBudget))
				.Count();

			var numberOfOpenProjectsWithUnknownBudget = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.OpenProjectsWithUnknownBudget))
				.Count();

			var numberOfOpenProjectsWithReachedTargetValue = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.OpenProjectsWithReachedTargetValue))
				.Count();

			var numberOfOpenProjectsWithMissedTargetValue = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.OpenProjectsWithMissedTargetValue))
				.Count();

			var numberOfOpenProjectsWithUnknownTargetValue = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.OpenProjectsWithUnknownTargetValue))
				.Count();

			var finishedProjects = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.FinishedProjects))
				.Count();

			var numberofFinishedProjectsWithSpentBudget = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.FinishedProjectsWithSpentBudget))
				.Count();
			
			var numberofFinishedProjectsWithUnspentBudget = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.FinishedProjectsWithUnspentBudget))
				.Count();

			var numberofFinishedProjectsWithUnknownBudget = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.FinishedProjectsWithUnknownBudget))
				.Count();

			var numberofFinishedProjectsWithReachedTargetValue = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.FinishedProjectsWithReachedTargetValue))
				.Count();

			var numberofFinishedProjectsWithMissedTargetValue = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.FinishedProjectsWithMissedTargetValue))
				.Count();

			var numberofFinishedProjectsWithUnknownTargetValue = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.FinishedProjectsWithUnknownTargetValue))
				.Count();

			var transactionTypeIndexViewModel = _transactionTypeService.BuildTransactionTypeIndexViewModel(userId);
			var paymentMethodIndexViewModel = _paymentMethodService.BuildPaymentMethodIndexViewModel(userId);

			var model = new HomeIndexViewModel
			{
				Projects = numberOfAllProjects,

				OpenProjects = numberOfOpenProjects,
				OpenProjectsWithSpentBudget = numberOfOpenProjectsWithSpentBudget,
				OpenProjectsWithUnspentBudget = numberOfOpenProjectsWithUnspentBudget,
				OpenProjectsWithUnknownBudget = numberOfOpenProjectsWithUnknownBudget,
				OpenProjectsWithReachedTargetValue = numberOfOpenProjectsWithReachedTargetValue,
				OpenProjectsWithMissedTargetValue = numberOfOpenProjectsWithMissedTargetValue,
				OpenProjectsWithUnknownTargetValue = numberOfOpenProjectsWithUnknownTargetValue,

				FinishedProjects = finishedProjects,
				FinishedProjectsWithSpentBudget = numberofFinishedProjectsWithSpentBudget,
				FinishedProjectsWithUnspentBudget = numberofFinishedProjectsWithUnspentBudget,
				FinishedProjectsWithUnknownBudget = numberofFinishedProjectsWithUnknownBudget,
				FinishedProjectsWithReachedTargetValue = numberofFinishedProjectsWithReachedTargetValue,
				FinishedProjectsWithMissedTargetValue = numberofFinishedProjectsWithMissedTargetValue,
				FinishedProjectsWithUnknownTargetValue = numberofFinishedProjectsWithUnknownTargetValue,

				TransactionTypeIndexViewModel = transactionTypeIndexViewModel,
				PaymentMethodIndexViewModel = paymentMethodIndexViewModel
			};
			return model;
		}
	}
}
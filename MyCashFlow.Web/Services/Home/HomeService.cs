﻿using MyCashFlow.Identity.Context;
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
		private readonly ApplicationDbContext _dbContext;
		private readonly ITransactionTypeService _transactionTypeService;
		private readonly IPaymentMethodService _paymentMethodService;

		public HomeService(
			ApplicationDbContext dbContext,
			ITransactionTypeService transactionTypeService,
			IPaymentMethodService paymentMethodService)
		{
			if (dbContext == null)
			{
				throw new ArgumentNullException(nameof(dbContext));
			}
			if (transactionTypeService == null)
			{
				throw new ArgumentNullException(nameof(transactionTypeService));
			}
			if (paymentMethodService == null)
			{
				throw new ArgumentNullException(nameof(paymentMethodService));
			}

			_dbContext = dbContext;
			_transactionTypeService = transactionTypeService;
			_paymentMethodService = paymentMethodService;
		}

		public HomeIndexViewModel BuildHomeIndexViewModel(int userId)
		{
			var myProjects = _dbContext.Projects.Where(x => x.CreatorID == userId);

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

			var numberOfOpenProjectsWithReachedTargetValue = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.OpenProjectsWithReachedTargetValue))
				.Count();

			var numberOfOpenProjectsWithMissedTargetValue = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.OpenProjectsWithMissedTargetValue))
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

			var numberofFinishedProjectsWithReachedTargetValue = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.FinishedProjectsWithReachedTargetValue))
				.Count();

			var numberofFinishedProjectsWithMissedTargetValue = myProjects
				.Where(ProjectsFilterTypeResolver.ResolveFilter(ProjectsFilterType.FinishedProjectsWithMissedTargetValue))
				.Count();

			var transactionTypeIndexViewModel = _transactionTypeService.BuildTransactionTypeIndexViewModel(userId);
			var paymentMethodIndexViewModel = _paymentMethodService.BuildPaymentMethodIndexViewModel(userId);

			var model = new HomeIndexViewModel
			{
				Projects = numberOfAllProjects,

				OpenProjects = numberOfOpenProjects,
				OpenProjectsWithSpentBudget = numberOfOpenProjectsWithSpentBudget,
				OpenProjectsWithUnspentBudget = numberOfOpenProjectsWithUnspentBudget,
				OpenProjectsWithReachedTargetValue = numberOfOpenProjectsWithReachedTargetValue,
				OpenProjectsWithMissedTargetValue = numberOfOpenProjectsWithMissedTargetValue,

				FinishedProjects = finishedProjects,
				FinishedProjectsWithSpentBudget = numberofFinishedProjectsWithSpentBudget,
				FinishedProjectsWithUnspentBudget = numberofFinishedProjectsWithUnspentBudget,
				FinishedProjectsWithReachedTargetValue = numberofFinishedProjectsWithReachedTargetValue,
				FinishedProjectsWithMissedTargetValue = numberofFinishedProjectsWithMissedTargetValue,

				TransactionTypeIndexViewModel = transactionTypeIndexViewModel,
				PaymentMethodIndexViewModel = paymentMethodIndexViewModel
			};
			return model;
		}
	}
}
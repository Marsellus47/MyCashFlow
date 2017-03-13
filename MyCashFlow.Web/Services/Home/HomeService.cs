using MyCashFlow.Repositories;
using MyCashFlow.Web.ViewModels.Home;
using System.Linq;
using System;
using MyCashFlow.Web.Services.TransactionType;
using MyCashFlow.Web.Services.PaymentMethod;

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
			var allProjects = _unitOfWork.ProjectRepository.Get(x => x.CreatorID == userId);
			var finishedProjects = allProjects.Where(x => x.ValidTill < DateTime.Now.Date);
			var openProjects = allProjects.Except(finishedProjects);
			var openFilledProjects = openProjects.Where(x => x.ActualValue >= x.Budget);
			var numberOfFinishedFilledProjects = finishedProjects.Where(x => x.ActualValue >= x.Budget).Count();
			var numberOfTotalFilledProjects = allProjects.Where(x => x.ActualValue >= x.Budget).Count();
			var numberOfNonFilledProjects = openProjects.Except(openFilledProjects).Count();
			var transactionTypeIndexViewModel = _transactionTypeService.BuildTransactionTypeIndexViewModel(userId);
			var paymentMethodIndexViewModel = _paymentMethodService.BuildPaymentMethodIndexViewModel(userId);

			var model = new HomeIndexViewModel
			{
				Projects = allProjects.Count(),
				FinishedProjects = finishedProjects.Count(),
				OpenProjects = openProjects.Count(),
				OpenFilledProjects = openFilledProjects.Count(),
				FinishedFilledProjects = numberOfFinishedFilledProjects,
				TotalFilledProjects = numberOfTotalFilledProjects,
				NonFilledProjects = numberOfNonFilledProjects,
				TransactionTypeIndexViewModel = transactionTypeIndexViewModel,
				PaymentMethodIndexViewModel = paymentMethodIndexViewModel
			};
			return model;
		}
	}
}
using AutoMapper;
using MyCashFlow.Repositories;
using MyCashFlow.Web.ViewModels.Transaction;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyCashFlow.Web.Services.Transaction
{
	public class TransactionService : ITransactionService
	{
		private readonly IUnitOfWork _unitOfWork;

		public TransactionService(IUnitOfWork unitOfWork)
		{
			if(unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}

			_unitOfWork = unitOfWork;
		}

		public TransactionIndexViewModel BuildTransactionIndexViewModel(int userId, int? projectId)
		{
			var transactions = _unitOfWork.TransactionRepository.Get(x => x.CreatorID == userId);

			if(projectId.HasValue)
			{
				transactions = transactions.Where(x => x.ProjectID == projectId.Value);
			}

			var items = Mapper.Map<IList<TransactionIndexItemViewModel>>(transactions);
			var model = new TransactionIndexViewModel
			{
				Items = items
			};

			return model;
		}

		public TransactionCreateViewModel BuildTransactionCreateViewModel(int userId, int? projectId)
		{
			IEnumerable<Domains.DataObject.Project> projects = null;
			if(!projectId.HasValue)
			{
				projects = _unitOfWork.ProjectRepository.Get(x => x.CreatorID == userId);
			}

			var transactionTypes = _unitOfWork.TransactionTypeRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);
			var paymentTypes = _unitOfWork.PaymentTypeRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);

			var model = new TransactionCreateViewModel
			{
				Date = DateTime.Now,
				ProjectID = projectId,
				Projects = projects,
				TransactionTypes = transactionTypes,
				PaymentTypes = paymentTypes
			};

			return model;
		}

		public void CreateTransaction(TransactionCreateViewModel model)
		{
			var transaction = Mapper.Map<Domains.DataObject.Transaction>(model);
			_unitOfWork.TransactionRepository.Insert(transaction);
			_unitOfWork.Save();
		}
	}
}
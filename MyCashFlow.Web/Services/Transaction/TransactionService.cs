using AutoMapper;
using MyCashFlow.Repositories.Repository;
using MyCashFlow.Web.ViewModels.Transaction;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyCashFlow.Web.Services.Transaction
{
	public class TransactionService : ITransactionService
	{
		private readonly IRepository<Domains.DataObject.Transaction> _transactionRepository;
		private readonly IRepository<Domains.DataObject.TransactionType> _transactionTypeRepository;
		private readonly IRepository<Domains.DataObject.Project> _projectRepository;
		private readonly IRepository<Domains.DataObject.PaymentMethod> _paymentMethodRepository;

		public TransactionService(
			IRepository<Domains.DataObject.Transaction> transactionRepository,
			IRepository<Domains.DataObject.TransactionType> transactionTypeRepository,
			IRepository<Domains.DataObject.Project> projectRepository,
			IRepository<Domains.DataObject.PaymentMethod> paymentMethodRepository)
		{
			if(transactionRepository == null)
			{
				throw new ArgumentNullException(nameof(transactionRepository));
			}
			if (transactionTypeRepository == null)
			{
				throw new ArgumentNullException(nameof(transactionTypeRepository));
			}
			if (projectRepository == null)
			{
				throw new ArgumentNullException(nameof(projectRepository));
			}
			if (paymentMethodRepository == null)
			{
				throw new ArgumentNullException(nameof(paymentMethodRepository));
			}

			_transactionRepository = transactionRepository;
			_transactionTypeRepository = transactionTypeRepository;
			_projectRepository = projectRepository;
			_paymentMethodRepository = paymentMethodRepository;
		}

		public TransactionIndexViewModel BuildTransactionIndexViewModel(int userId, int? projectId)
		{
			var transactions = _transactionRepository.Get(x => x.CreatorID == userId);

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
			IList<Domains.DataObject.Project> projects = null;
			if(!projectId.HasValue)
			{
				projects = _projectRepository.Get(x => x.CreatorID == userId).ToList();
			}
			else
			{
				projects = _projectRepository.Get(x => x.ProjectID == projectId.Value).ToList();
			}

			var transactionTypes = _transactionTypeRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);
			var paymentMethods = _paymentMethodRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);

			var model = new TransactionCreateViewModel
			{
				Date = DateTime.Now,
				ProjectID = projectId,
				Projects = projects,
				TransactionTypes = transactionTypes,
				PaymentMethods = paymentMethods
			};

			return model;
		}

		public void CreateTransaction(TransactionCreateViewModel model)
		{
			var transaction = Mapper.Map<Domains.DataObject.Transaction>(model);
			_transactionRepository.Insert(transaction);
		}

		public TransactionEditViewModel BuildTransactionEditViewModel(int userId, int transactionId)
		{
			var transaction = _transactionRepository.GetByID(transactionId);
			var model = Mapper.Map<TransactionEditViewModel>(transaction);
			if (!transaction.ProjectID.HasValue)
			{
				model.Projects = _projectRepository.Get(x => x.CreatorID == userId).ToList();
			}
			else
			{
				model.Projects = _projectRepository.Get(x => x.ProjectID == transaction.ProjectID.Value).ToList();
			}
			model.TransactionTypes = _transactionTypeRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);
			model.PaymentMethods = _paymentMethodRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);

			return model;
		}

		public void EditTransaction(TransactionEditViewModel model)
		{
			var transaction = Mapper.Map<Domains.DataObject.Transaction>(model);
			_transactionRepository.Update(transaction);
			var original = _transactionRepository.GetOriginal(transaction);
			;
		}

		public TransactionDetailsViewModel BuildTransactionDetailsViewModel(int transactionId)
		{
			var transaction = _transactionRepository.GetByID(transactionId);
			var model = Mapper.Map<TransactionDetailsViewModel>(transaction);

			if (transaction.ProjectID.HasValue)
			{
				var project = _projectRepository.GetByID(transaction.ProjectID.Value);
				model.ProjectName = project.Name;
			}

			var transactionType = _transactionTypeRepository.GetByID(transaction.TransactionTypeID);
			model.TransactionTypeName = transactionType.Name;

			if (transaction.PaymentMethodID.HasValue)
			{
				var paymentMethod = _paymentMethodRepository.GetByID(transaction.PaymentMethodID.Value);
				model.PaymentMethodName = paymentMethod.Name;
			}

			return model;
		}

		public TransactionDeleteViewModel BuildTransactionDeleteViewModel(int transactionId)
		{
			var transaction = _transactionRepository.GetByID(transactionId);
			var model = Mapper.Map<TransactionDeleteViewModel>(transaction);
			return model;
		}

		public void DeleteTransaction(int transactionId)
		{
			_transactionRepository.Delete(transactionId);
		}
	}
}
using AutoMapper;
using MyCashFlow.Identity.Context;
using MyCashFlow.Web.ViewModels.Transaction;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace MyCashFlow.Web.Services.Transaction
{
	public class TransactionService : ITransactionService
	{
		private readonly ApplicationDbContext _dbContext;

		public TransactionService(ApplicationDbContext dbContext)
		{
			if(dbContext == null)
			{
				throw new ArgumentNullException(nameof(dbContext));
			}

			_dbContext = dbContext;
		}

		public TransactionIndexViewModel BuildTransactionIndexViewModel(int userId, int? projectId)
		{
			var transactions = _dbContext.Transactions.Where(x => x.CreatorID == userId);

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
				projects = _dbContext.Projects.Where(x => x.CreatorID == userId).ToList();
			}
			else
			{
				projects = _dbContext.Projects.Where(x => x.ProjectID == projectId.Value).ToList();
			}

			var transactionTypes = _dbContext.TransactionTypes.Where(x => x.CreatorID == userId || x.CreatorID == null);
			var paymentMethods = _dbContext.PaymentMethods.Where(x => x.CreatorID == userId || x.CreatorID == null);

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
			_dbContext.Transactions.Add(transaction);

			if(transaction.ProjectID.HasValue)
			{
				var project = _dbContext.Projects.Find(transaction.ProjectID.Value);
				project.ActualValue = project.ActualValue + (transaction.Income ? 1 : -1 * transaction.Amount);
			}
			_dbContext.SaveChanges();
		}

		public TransactionEditViewModel BuildTransactionEditViewModel(int userId, int transactionId)
		{
			var transaction = _dbContext.Transactions.Find(transactionId);
			var model = Mapper.Map<TransactionEditViewModel>(transaction);
			if (!transaction.ProjectID.HasValue)
			{
				model.Projects = _dbContext.Projects.Where(x => x.CreatorID == userId).ToList();
			}
			else
			{
				model.Projects = _dbContext.Projects.Where(x => x.ProjectID == transaction.ProjectID.Value).ToList();
			}
			model.TransactionTypes = _dbContext.TransactionTypes.Where(x => x.CreatorID == userId || x.CreatorID == null);
			model.PaymentMethods = _dbContext.PaymentMethods.Where(x => x.CreatorID == userId || x.CreatorID == null);

			return model;
		}

		public void EditTransaction(TransactionEditViewModel model)
		{
			var transaction = Mapper.Map<Domains.DataObject.Transaction>(model);
			_dbContext.Entry(transaction).State = EntityState.Modified;

			var originalTransaction = _dbContext.GetOriginal(transaction);

			// When Transaction Amount has changed
			if(((originalTransaction.Income ? 1 : -1) * originalTransaction.Amount) != ((transaction.Income ? 1 : -1) * transaction.Amount))
			{
				// Set original Project's Actual value
				if(originalTransaction.ProjectID.HasValue)
				{
					var originalProject = _dbContext.Projects.Find(originalTransaction.ProjectID.Value);
					originalProject.ActualValue = originalProject.ActualValue + ((originalTransaction.Income ? -1 : 1) * originalTransaction.Amount);
					_dbContext.Entry(originalProject).State = EntityState.Modified;
				}

				// and also set the actual Project's Actual value
				if(transaction.ProjectID.HasValue)
				{
					var project = _dbContext.Projects.Find(transaction.ProjectID.Value);
					project.ActualValue = project.ActualValue + ((transaction.Income ? 1 : -1) * transaction.Amount);
					_dbContext.Entry(project).State = EntityState.Modified;
				}
			}
			_dbContext.SaveChanges();
		}

		public TransactionDetailsViewModel BuildTransactionDetailsViewModel(int transactionId)
		{
			var transaction = _dbContext.Transactions.Find(transactionId);
			var model = Mapper.Map<TransactionDetailsViewModel>(transaction);

			if (transaction.ProjectID.HasValue)
			{
				var project = _dbContext.Projects.Find(transaction.ProjectID.Value);
				model.ProjectName = project.Name;
			}

			var transactionType = _dbContext.TransactionTypes.Find(transaction.TransactionTypeID);
			model.TransactionTypeName = transactionType.Name;

			if (transaction.PaymentMethodID.HasValue)
			{
				var paymentMethod = _dbContext.PaymentMethods.Find(transaction.PaymentMethodID.Value);
				model.PaymentMethodName = paymentMethod.Name;
			}

			return model;
		}

		public TransactionDeleteViewModel BuildTransactionDeleteViewModel(int transactionId)
		{
			var transaction = _dbContext.Transactions.Find(transactionId);
			var model = Mapper.Map<TransactionDeleteViewModel>(transaction);
			return model;
		}

		public void DeleteTransaction(int transactionId)
		{
			var transaction = _dbContext.Transactions.Find(transactionId);
			_dbContext.Transactions.Remove(transaction);
			_dbContext.SaveChanges();
		}
	}
}
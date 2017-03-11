﻿using AutoMapper;
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
			IList<Domains.DataObject.Project> projects = null;
			if(!projectId.HasValue)
			{
				projects = _unitOfWork.ProjectRepository.Get(x => x.CreatorID == userId).ToList();
			}
			else
			{
				projects = _unitOfWork.ProjectRepository.Get(x => x.ProjectID == projectId.Value).ToList();
			}

			var transactionTypes = _unitOfWork.TransactionTypeRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);
			var paymentMethods = _unitOfWork.PaymentMethodRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);

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
			_unitOfWork.TransactionRepository.Insert(transaction);
			_unitOfWork.Save();
		}

		public TransactionEditViewModel BuildTransactionEditViewModel(int userId, int transactionId)
		{
			var transaction = _unitOfWork.TransactionRepository.GetByID(transactionId);
			var model = Mapper.Map<TransactionEditViewModel>(transaction);
			if (!transaction.ProjectID.HasValue)
			{
				model.Projects = _unitOfWork.ProjectRepository.Get(x => x.CreatorID == userId).ToList();
			}
			else
			{
				model.Projects = _unitOfWork.ProjectRepository.Get(x => x.ProjectID == transaction.ProjectID.Value).ToList();
			}
			model.TransactionTypes = _unitOfWork.TransactionTypeRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);
			model.PaymentMethods = _unitOfWork.PaymentMethodRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);

			return model;
		}

		public void EditTransaction(TransactionEditViewModel model)
		{
			var transaction = Mapper.Map<Domains.DataObject.Transaction>(model);
			_unitOfWork.TransactionRepository.Update(transaction);
			_unitOfWork.Save();
		}

		public TransactionDetailsViewModel BuildTransactionDetailsViewModel(int transactionId)
		{
			var transaction = _unitOfWork.TransactionRepository.GetByID(transactionId);
			var model = Mapper.Map<TransactionDetailsViewModel>(transaction);

			if (transaction.ProjectID.HasValue)
			{
				var project = _unitOfWork.ProjectRepository.GetByID(transaction.ProjectID.Value);
				model.ProjectName = project.Name;
			}

			var transactionType = _unitOfWork.TransactionTypeRepository.GetByID(transaction.TransactionTypeID);
			model.TransactionTypeName = transactionType.Name;

			if (transaction.PaymentMethodID.HasValue)
			{
				var paymentMethod = _unitOfWork.PaymentMethodRepository.GetByID(transaction.PaymentMethodID.Value);
				model.PaymentMethodName = paymentMethod.Name;
			}

			return model;
		}

		public TransactionDeleteViewModel BuildTransactionDeleteViewModel(int transactionId)
		{
			var transaction = _unitOfWork.TransactionRepository.GetByID(transactionId);
			var model = Mapper.Map<TransactionDeleteViewModel>(transaction);
			return model;
		}

		public void DeleteTransaction(int transactionId)
		{
			_unitOfWork.TransactionRepository.Delete(transactionId);
			_unitOfWork.Save();
		}
	}
}
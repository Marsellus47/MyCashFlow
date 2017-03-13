using AutoMapper;
using MyCashFlow.Repositories;
using MyCashFlow.Web.ViewModels.TransactionType;
using System.Collections.Generic;
using System;

namespace MyCashFlow.Web.Services.TransactionType
{
	public class TransactionTypeService : ITransactionTypeService
	{
		private readonly IUnitOfWork _unitOfWork;

		public TransactionTypeService(IUnitOfWork unitOfWork)
		{
			if(unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}

			_unitOfWork = unitOfWork;
		}

		public TransactionTypeIndexViewModel BuildTransactionTypeIndexViewModel(int userId)
		{
			var transactionTypes = _unitOfWork.TransactionTypeRepository.Get(x => x.CreatorID == userId || x.CreatorID == null);
			var items = Mapper.Map<IList<TransactionTypeIndexItemViewModel>>(transactionTypes);
			var model = new TransactionTypeIndexViewModel
			{
				Items = items
			};
			return model;
		}

		public TransactionTypeCreateViewModel BuildTransactionTypeCreateViewModel(string previousUrl)
		{
			var model = new TransactionTypeCreateViewModel
			{
				PreviousUrl = previousUrl
			};
			return model;
		}

		public void CreateTransactionType(TransactionTypeCreateViewModel model)
		{
			var transactionType = Mapper.Map<Domains.DataObject.TransactionType>(model);
			_unitOfWork.TransactionTypeRepository.Insert(transactionType);
			_unitOfWork.Save();
		}

		public TransactionTypeEditViewModel BuildTransactionTypeEditViewModel(int transactionTypeId)
		{
			var transaction = _unitOfWork.TransactionTypeRepository.GetByID(transactionTypeId);
			var model = Mapper.Map<TransactionTypeEditViewModel>(transaction);
			return model;
		}

		public void EditTransactionType(TransactionTypeEditViewModel model)
		{
			var transactionType = Mapper.Map<Domains.DataObject.TransactionType>(model);
			_unitOfWork.TransactionTypeRepository.Update(transactionType);
			_unitOfWork.Save();
		}

		public TransactionTypeDetailsViewModel BuildTransactionTypeDetailsViewModel(int transactionTypeId)
		{
			var transactionType = _unitOfWork.TransactionTypeRepository.GetByID(transactionTypeId);
			var model = Mapper.Map<TransactionTypeDetailsViewModel>(transactionType);
			return model;
		}

		public TransactionTypeDeleteViewModel BuildTransactionTypeDeleteViewModel(int transactionTypeId)
		{
			var transactionType = _unitOfWork.TransactionTypeRepository.GetByID(transactionTypeId);
			var model = Mapper.Map<TransactionTypeDeleteViewModel>(transactionType);
			return model;
		}

		public void DeleteTransactionType(int transactionTypeId)
		{
			_unitOfWork.TransactionTypeRepository.Delete(transactionTypeId);
			_unitOfWork.Save();
		}
	}
}
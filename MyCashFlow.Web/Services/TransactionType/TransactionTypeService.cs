using AutoMapper;
using MyCashFlow.Repositories.Repository;
using MyCashFlow.Web.ViewModels.TransactionType;
using System.Collections.Generic;
using System;

namespace MyCashFlow.Web.Services.TransactionType
{
	public class TransactionTypeService : ITransactionTypeService
	{
		private readonly IRepository<Domains.DataObject.TransactionType> _transactionTypeRepository;

		public TransactionTypeService(IRepository<Domains.DataObject.TransactionType> transactionTypeRepository)
		{
			if(transactionTypeRepository == null)
			{
				throw new ArgumentNullException(nameof(transactionTypeRepository));
			}

			_transactionTypeRepository = transactionTypeRepository;
		}

		public TransactionTypeIndexViewModel BuildTransactionTypeIndexViewModel(int userId)
		{
			var transactionTypes = _transactionTypeRepository.Get(x => x.CreatorID == userId || !x.CreatorID.HasValue);
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
			_transactionTypeRepository.Insert(transactionType);
		}

		public TransactionTypeEditViewModel BuildTransactionTypeEditViewModel(int transactionTypeId)
		{
			var transaction = _transactionTypeRepository.GetByID(transactionTypeId);
			var model = Mapper.Map<TransactionTypeEditViewModel>(transaction);
			return model;
		}

		public void EditTransactionType(TransactionTypeEditViewModel model)
		{
			var transactionType = Mapper.Map<Domains.DataObject.TransactionType>(model);
			_transactionTypeRepository.Update(transactionType);
		}

		public TransactionTypeDetailsViewModel BuildTransactionTypeDetailsViewModel(int transactionTypeId)
		{
			var transactionType = _transactionTypeRepository.GetByID(transactionTypeId);
			var model = Mapper.Map<TransactionTypeDetailsViewModel>(transactionType);
			return model;
		}

		public TransactionTypeDeleteViewModel BuildTransactionTypeDeleteViewModel(int transactionTypeId)
		{
			var transactionType = _transactionTypeRepository.GetByID(transactionTypeId);
			var model = Mapper.Map<TransactionTypeDeleteViewModel>(transactionType);
			return model;
		}

		public void DeleteTransactionType(int transactionTypeId)
		{
			_transactionTypeRepository.Delete(transactionTypeId);
		}
	}
}
using AutoMapper;
using MyCashFlow.Identity.Context;
using MyCashFlow.Web.ViewModels.TransactionType;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyCashFlow.Web.Services.TransactionType
{
	public class TransactionTypeService : ITransactionTypeService
	{
		private readonly ApplicationDbContext _dbContext;

		public TransactionTypeService(ApplicationDbContext dbContext)
		{
			if(dbContext == null)
			{
				throw new ArgumentNullException(nameof(dbContext));
			}

			_dbContext = dbContext;
		}

		public TransactionTypeIndexViewModel BuildTransactionTypeIndexViewModel(int userId)
		{
			var transactionTypes = _dbContext.TransactionTypes.Where(x => x.CreatorID == userId || !x.CreatorID.HasValue);
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
			_dbContext.TransactionTypes.Add(transactionType);
			_dbContext.SaveChanges();
		}

		public TransactionTypeEditViewModel BuildTransactionTypeEditViewModel(int transactionTypeId)
		{
			var transaction = _dbContext.TransactionTypes.Find(transactionTypeId);
			var model = Mapper.Map<TransactionTypeEditViewModel>(transaction);
			return model;
		}

		public void EditTransactionType(TransactionTypeEditViewModel model)
		{
			var transactionType = Mapper.Map<Domains.DataObject.TransactionType>(model);
			_dbContext.Entry(transactionType).State = System.Data.Entity.EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public TransactionTypeDetailsViewModel BuildTransactionTypeDetailsViewModel(int transactionTypeId)
		{
			var transactionType = _dbContext.TransactionTypes.Find(transactionTypeId);
			var model = Mapper.Map<TransactionTypeDetailsViewModel>(transactionType);
			return model;
		}

		public TransactionTypeDeleteViewModel BuildTransactionTypeDeleteViewModel(int transactionTypeId)
		{
			var transactionType = _dbContext.TransactionTypes.Find(transactionTypeId);
			var model = Mapper.Map<TransactionTypeDeleteViewModel>(transactionType);
			return model;
		}

		public void DeleteTransactionType(int transactionTypeId)
		{
			var transactionType = _dbContext.TransactionTypes.Find(transactionTypeId);
			_dbContext.TransactionTypes.Remove(transactionType);
			_dbContext.SaveChanges();
		}
	}
}
using AutoMapper;
using MyCashFlow.Identity.Context;
using MyCashFlow.Web.ViewModels.Transaction;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyCashFlow.Web.Services.Transaction
{
	public class ApiTransactionService : IApiTransactionService
	{
		private readonly ApplicationDbContext _dbContext;

		public ApiTransactionService(ApplicationDbContext dbContext)
		{
			if(dbContext == null)
			{
				throw new ArgumentNullException(nameof(dbContext));
			}

			_dbContext = dbContext;
		}

		public IEnumerable<TransactionIndexItemViewModel> GetAll(int userId, int? projectId)
		{
			var transactions = _dbContext.Transactions.Where(x => x.CreatorID == userId);
			if (projectId.HasValue)
			{
				transactions = transactions.Where(x => x.ProjectID == projectId.Value);
			}
			var result = Mapper.Map<IEnumerable<TransactionIndexItemViewModel>>(transactions);
			return result;
		}

		public void Delete(int id)
		{
			var transaction = _dbContext.Transactions.Find(id);
			_dbContext.Transactions.Remove(transaction);
			_dbContext.SaveChanges();
		}
	}
}
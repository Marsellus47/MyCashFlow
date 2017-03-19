using AutoMapper;
using MyCashFlow.Repositories.Repository;
using MyCashFlow.Web.ViewModels.Transaction;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyCashFlow.Web.Services.Transaction
{
	public class ApiTransactionService : IApiTransactionService
	{
		private readonly IRepository<Domains.DataObject.Transaction> _transactionRepository;

		public ApiTransactionService(IRepository<Domains.DataObject.Transaction> transactionRepository)
		{
			if(transactionRepository == null)
			{
				throw new ArgumentNullException(nameof(transactionRepository));
			}

			_transactionRepository = transactionRepository;
		}

		public IEnumerable<TransactionIndexItemViewModel> GetAll(int userId, int? projectId)
		{
			var transactions = _transactionRepository.Get(x => x.CreatorID == userId);
			if (projectId.HasValue)
			{
				transactions = transactions.Where(x => x.ProjectID == projectId.Value);
			}
			var result = Mapper.Map<IEnumerable<TransactionIndexItemViewModel>>(transactions);
			return result;
		}

		public void Delete(int id)
		{
			_transactionRepository.Delete(id);
		}
	}
}
using MyCashFlow.Repositories.Repository;
using System.Collections.Generic;
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

		public IEnumerable<Domains.DataObject.Transaction> GetAll(int? userId, int? projectId)
		{
			if(!userId.HasValue && !projectId.HasValue)
			{
				throw new InvalidOperationException($"One of {nameof(userId)} or {nameof(projectId)} can't be empty");
			}
			if (userId.HasValue && projectId.HasValue)
			{
				throw new InvalidOperationException($"Only one of {nameof(userId)} or {nameof(projectId)} has to be filled");
			}
			
			if(userId.HasValue)
			{
				var transactions = _transactionRepository.Get(x => x.CreatorID == userId.Value);
				return transactions;
			}
			else
			{
				var transactions = _transactionRepository.Get(x => x.ProjectID == projectId.Value);
				return transactions;
			}
		}
	}
}
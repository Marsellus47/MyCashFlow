using MyCashFlow.Domains.DataObject;
using MyCashFlow.Web.Services.Transaction;
using System.Collections.Generic;
using System.Web.Http;
using System;

namespace MyCashFlow.Web.Controllers
{
	public class ApiTransactionController : ApiController
    {
		private readonly IApiTransactionService _apiTransactionService;

		public ApiTransactionController(IApiTransactionService apiTransactionService)
		{
			if(apiTransactionService == null)
			{
				throw new ArgumentNullException(nameof(apiTransactionService));
			}

			_apiTransactionService = apiTransactionService;
		}

		[HttpGet]
		public IEnumerable<Transaction> GetAll(int? userId, int? projectId)
		{
			var transactions = _apiTransactionService.GetAll(userId, projectId);
			return transactions;
		}

		public IEnumerable<Transaction> GetAll()
		{
			var transactions = _apiTransactionService.GetAll(1, null);
			return transactions;
		}
    }
}

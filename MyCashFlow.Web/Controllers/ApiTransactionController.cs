using Microsoft.AspNet.Identity;
using MyCashFlow.Web.Services.Transaction;
using MyCashFlow.Web.ViewModels.Transaction;
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
		
		public IEnumerable<TransactionIndexItemViewModel> GetAll(int? id = null)
		{
			var userId = User.Identity.GetUserId<int>();
			var transactions = _apiTransactionService.GetAll(userId, id);
			return transactions;
		}

		public void DeleteTransaction(int id)
		{
			_apiTransactionService.Delete(id);
		}
    }
}

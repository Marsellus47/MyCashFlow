using Microsoft.AspNet.Identity;
using MyCashFlow.Web.Services.Transaction;
using MyCashFlow.Web.ViewModels.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;
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
		
		public async Task<IEnumerable<TransactionIndexItemViewModel>> GetAllTransactions(int? id = null)
		{
			var userId = User.Identity.GetUserId<int>();
			var transactions = await _apiTransactionService.GetAllAsync(userId, id);
			return transactions;
		}

		public async Task<TransactionDetailsViewModel> GetTransaction(int id)
		{
			var result = await _apiTransactionService.GetAsync(id);
			return result;
		}

		public async Task<TransactionIndexItemViewModel> PostTransaction(TransactionCreateViewModel model)
		{
			model.CreatorID = User.Identity.GetUserId<int>();
			var result = await _apiTransactionService.Create(model);
			return result;
		}

		public async Task PutTransaction(TransactionEditViewModel model)
		{
			await _apiTransactionService.Edit(model);
		}

		public async Task DeleteTransaction(int id)
		{
			await _apiTransactionService.DeleteAsync(id);
		}
    }
}

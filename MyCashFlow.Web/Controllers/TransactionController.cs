using MyCashFlow.Web.Infrastructure.Controllers;
using MyCashFlow.Web.Services.Transaction;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace MyCashFlow.Web.Controllers
{
	public class TransactionController : UserManagerBasedController
	{
		private readonly ITransactionService _transactionService;

		public TransactionController(ITransactionService transactionService)
		{
			if(transactionService == null)
			{
				throw new ArgumentNullException(nameof(transactionService));
			}

			_transactionService = transactionService;
		}

        public async Task<ActionResult> Index(int? projectId)
        {
			int userId = await GetCurrentUserIdAsync();
			var model = _transactionService.BuildTransactionIndexViewModel(userId, projectId);
            return View(model);
        }
    }
}
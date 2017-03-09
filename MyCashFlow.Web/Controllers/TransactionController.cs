using MyCashFlow.Web.Infrastructure.Controllers;
using MyCashFlow.Web.Services.Transaction;
using MyCashFlow.Web.ViewModels.Transaction;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace MyCashFlow.Web.Controllers
{
	public partial class TransactionController : UserManagerBasedController
	{
		private readonly ITransactionService _transactionService;

		public TransactionController(ITransactionService transactionService)
		{
			if (transactionService == null)
			{
				throw new ArgumentNullException(nameof(transactionService));
			}

			_transactionService = transactionService;
		}

		public virtual async Task<ActionResult> Index(int? projectId)
		{
			int userId = await GetCurrentUserIdAsync();
			var model = _transactionService.BuildTransactionIndexViewModel(userId, projectId);
			return View(model);
		}

		public virtual async Task<ActionResult> Create(int? projectId)
		{
			int userId = await GetCurrentUserIdAsync();
			var model = _transactionService.BuildTransactionCreateViewModel(userId, projectId);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Create(TransactionCreateViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.CreatorID = await GetCurrentUserIdAsync();
			_transactionService.CreateTransaction(model);

			return RedirectToAction(MVC.Project.ActionNames.Index);
		}
	}
}
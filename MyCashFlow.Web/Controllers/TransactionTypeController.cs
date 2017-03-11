using MyCashFlow.Web.Infrastructure.Controllers;
using MyCashFlow.Web.Services.TransactionType;
using MyCashFlow.Web.ViewModels.TransactionType;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace MyCashFlow.Web.Controllers
{
	public partial class TransactionTypeController : UserManagerBasedController
	{
		private readonly ITransactionTypeService _transactionTypeService;

		public TransactionTypeController(ITransactionTypeService transactionTypeService)
		{
			if (transactionTypeService == null)
			{
				throw new ArgumentNullException(nameof(transactionTypeService));
			}

			_transactionTypeService = transactionTypeService;
		}

		public virtual ActionResult Create(string previousUrl)
		{
			var model = _transactionTypeService.BuildTransactionTypeCreateViewModel(previousUrl);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Create(TransactionTypeCreateViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.CreatorID = await GetCurrentUserIdAsync();
			_transactionTypeService.CreateTransactionType(model);

			if(string.IsNullOrEmpty(model.PreviousUrl))
			{
				return View("Index");
			}
			return Redirect(model.PreviousUrl);
		}
	}
}
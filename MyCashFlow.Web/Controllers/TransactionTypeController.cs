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

		public virtual async Task<ActionResult> Index()
		{
			int userId = await GetCurrentUserIdAsync();
			var model = _transactionTypeService.BuildTransactionTypeIndexViewModel(userId);
			return View(MVC.TransactionType.Views._Index, model);
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
				return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
			}
			return Redirect(model.PreviousUrl);
		}

		public virtual ActionResult Edit(int id)
		{
			var model = _transactionTypeService.BuildTransactionTypeEditViewModel(id);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Edit(TransactionTypeEditViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.CreatorID = await GetCurrentUserIdAsync();
			_transactionTypeService.EditTransactionType(model);
			return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
		}

		public virtual ActionResult Details(int id)
		{
			var model = _transactionTypeService.BuildTransactionTypeDetailsViewModel(id);
			return View(model);
		}

		public virtual ActionResult Delete(int id)
		{
			var model = _transactionTypeService.BuildTransactionTypeDeleteViewModel(id);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult PostDelete(int id)
		{
			_transactionTypeService.DeleteTransactionType(id);
			return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
		}
	}
}
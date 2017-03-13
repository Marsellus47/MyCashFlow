using MyCashFlow.Web.Infrastructure.Controllers;
using MyCashFlow.Web.Services.PaymentMethod;
using MyCashFlow.Web.ViewModels.PaymentMethod;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace MyCashFlow.Web.Controllers
{
	public partial class PaymentMethodController : UserManagerBasedController
	{
		private readonly IPaymentMethodService _paymentMethodService;

		public PaymentMethodController(IPaymentMethodService paymentMethodService)
		{
			if (paymentMethodService == null)
			{
				throw new ArgumentNullException(nameof(paymentMethodService));
			}

			_paymentMethodService = paymentMethodService;
		}

		public virtual async Task<ActionResult> Index()
		{
			var userId = await GetCurrentUserIdAsync();
			var model = _paymentMethodService.BuildPaymentMethodIndexViewModel(userId);
			return View(MVC.PaymentMethod.Views._Index, model);
		}

		public virtual ActionResult Create(string previousUrl)
		{
			var model = _paymentMethodService.BuildPaymentMethodCreateViewModel(previousUrl);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Create(PaymentMethodCreateViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.CreatorID = await GetCurrentUserIdAsync();
			_paymentMethodService.CreatePaymentMethod(model);

			if (string.IsNullOrEmpty(model.PreviousUrl))
			{
				return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
			}
			return Redirect(model.PreviousUrl);
		}

		public virtual ActionResult Edit(int id)
		{
			var model = _paymentMethodService.BuildPaymentMethodEditViewModel(id);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Edit(PaymentMethodEditViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.CreatorID = await GetCurrentUserIdAsync();
			_paymentMethodService.EditPaymentMethod(model);
			return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
		}

		public virtual ActionResult Details(int id)
		{
			var model = _paymentMethodService.BuildPaymentMethodDetailsViewModel(id);
			return View(model);
		}

		public virtual ActionResult Delete(int id)
		{
			var model = _paymentMethodService.BuildPaymentMethodDeleteViewModel(id);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult PostDelete(int id)
		{
			_paymentMethodService.DeletePaymentMethod(id);
			return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
		}
	}
}
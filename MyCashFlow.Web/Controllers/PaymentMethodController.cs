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
				return View("Index");
			}
			return Redirect(model.PreviousUrl);
		}
	}
}
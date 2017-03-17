using AutoMapper;
using MyCashFlow.Repositories.Repository;
using MyCashFlow.Web.ViewModels.PaymentMethod;
using System.Collections.Generic;
using System;

namespace MyCashFlow.Web.Services.PaymentMethod
{
	public class PaymentMethodService : IPaymentMethodService
	{
		private readonly IRepository<Domains.DataObject.PaymentMethod> _paymentMethodRepository;

		public PaymentMethodService(IRepository<Domains.DataObject.PaymentMethod> paymentMethodRepository)
		{
			if(paymentMethodRepository == null)
			{
				throw new ArgumentNullException(nameof(paymentMethodRepository));
			}

			_paymentMethodRepository = paymentMethodRepository;
		}

		public PaymentMethodIndexViewModel BuildPaymentMethodIndexViewModel(int userId)
		{
			var paymentMethods = _paymentMethodRepository.Get(x => x.CreatorID == userId || !x.CreatorID.HasValue);
			var items = Mapper.Map<IList<PaymentMethodIndexItemViewModel>>(paymentMethods);
			var model = new PaymentMethodIndexViewModel
			{
				Items = items
			};
			return model;
		}

		public PaymentMethodCreateViewModel BuildPaymentMethodCreateViewModel(string previousUrl)
		{
			var model = new PaymentMethodCreateViewModel
			{
				PreviousUrl = previousUrl
			};
			return model;
		}

		public void CreatePaymentMethod(PaymentMethodCreateViewModel model)
		{
			var paymentMethod = Mapper.Map<Domains.DataObject.PaymentMethod>(model);
			_paymentMethodRepository.Insert(paymentMethod);
		}

		public PaymentMethodEditViewModel BuildPaymentMethodEditViewModel(int paymentMethodId)
		{
			var paymentMethod = _paymentMethodRepository.GetByID(paymentMethodId);
			var model = Mapper.Map<PaymentMethodEditViewModel>(paymentMethod);
			return model;
		}

		public void EditPaymentMethod(PaymentMethodEditViewModel model)
		{
			var paymentMethod = Mapper.Map<Domains.DataObject.PaymentMethod>(model);
			_paymentMethodRepository.Update(paymentMethod);
		}

		public PaymentMethodDetailsViewModel BuildPaymentMethodDetailsViewModel(int paymentMethodId)
		{
			var paymentMethod = _paymentMethodRepository.GetByID(paymentMethodId);
			var model = Mapper.Map<PaymentMethodDetailsViewModel>(paymentMethod);
			return model;
		}

		public PaymentMethodDeleteViewModel BuildPaymentMethodDeleteViewModel(int paymentMethodId)
		{
			var paymentMethod = _paymentMethodRepository.GetByID(paymentMethodId);
			var model = Mapper.Map<PaymentMethodDeleteViewModel>(paymentMethod);
			return model;
		}

		public void DeletePaymentMethod(int paymentMethodId)
		{
			_paymentMethodRepository.Delete(paymentMethodId);
		}
	}
}
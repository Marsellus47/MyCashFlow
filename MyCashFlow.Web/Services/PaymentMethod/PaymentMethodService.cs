using AutoMapper;
using MyCashFlow.Repositories;
using MyCashFlow.Web.ViewModels.PaymentMethod;
using System.Collections.Generic;
using System;

namespace MyCashFlow.Web.Services.PaymentMethod
{
	public class PaymentMethodService : IPaymentMethodService
	{
		private readonly IUnitOfWork _unitOfWork;

		public PaymentMethodService(IUnitOfWork unitOfWork)
		{
			if(unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}

			_unitOfWork = unitOfWork;
		}

		public PaymentMethodIndexViewModel BuildPaymentMethodIndexViewModel(int userId)
		{
			var paymentMethods = _unitOfWork.PaymentMethodRepository.Get(x => x.CreatorID == userId || !x.CreatorID.HasValue);
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
			_unitOfWork.PaymentMethodRepository.Insert(paymentMethod);
			_unitOfWork.Save();
		}

		public PaymentMethodEditViewModel BuildPaymentMethodEditViewModel(int paymentMethodId)
		{
			var paymentMethod = _unitOfWork.PaymentMethodRepository.GetByID(paymentMethodId);
			var model = Mapper.Map<PaymentMethodEditViewModel>(paymentMethod);
			return model;
		}

		public void EditPaymentMethod(PaymentMethodEditViewModel model)
		{
			var paymentMethod = Mapper.Map<Domains.DataObject.PaymentMethod>(model);
			_unitOfWork.PaymentMethodRepository.Update(paymentMethod);
			_unitOfWork.Save();
		}

		public PaymentMethodDetailsViewModel BuildPaymentMethodDetailsViewModel(int paymentMethodId)
		{
			var paymentMethod = _unitOfWork.PaymentMethodRepository.GetByID(paymentMethodId);
			var model = Mapper.Map<PaymentMethodDetailsViewModel>(paymentMethod);
			return model;
		}

		public PaymentMethodDeleteViewModel BuildPaymentMethodDeleteViewModel(int paymentMethodId)
		{
			var paymentMethod = _unitOfWork.PaymentMethodRepository.GetByID(paymentMethodId);
			var model = Mapper.Map<PaymentMethodDeleteViewModel>(paymentMethod);
			return model;
		}

		public void DeletePaymentMethod(int paymentMethodId)
		{
			_unitOfWork.PaymentMethodRepository.Delete(paymentMethodId);
			_unitOfWork.Save();
		}
	}
}
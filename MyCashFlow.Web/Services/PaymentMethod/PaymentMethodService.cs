using AutoMapper;
using MyCashFlow.Repositories;
using MyCashFlow.Web.ViewModels.PaymentMethod;
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
	}
}
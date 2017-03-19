using AutoMapper;
using MyCashFlow.Identity.Context;
using MyCashFlow.Web.ViewModels.PaymentMethod;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyCashFlow.Web.Services.PaymentMethod
{
	public class PaymentMethodService : IPaymentMethodService
	{
		private readonly ApplicationDbContext _dbContext;

		public PaymentMethodService(ApplicationDbContext dbContext)
		{
			if(dbContext == null)
			{
				throw new ArgumentNullException(nameof(dbContext));
			}

			_dbContext = dbContext;
		}

		public PaymentMethodIndexViewModel BuildPaymentMethodIndexViewModel(int userId)
		{
			var paymentMethods = _dbContext.PaymentMethods.Where(x => x.CreatorID == userId || !x.CreatorID.HasValue);
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
			_dbContext.PaymentMethods.Add(paymentMethod);
			_dbContext.SaveChanges();
		}

		public PaymentMethodEditViewModel BuildPaymentMethodEditViewModel(int paymentMethodId)
		{
			var paymentMethod = _dbContext.PaymentMethods.Find(paymentMethodId);
			var model = Mapper.Map<PaymentMethodEditViewModel>(paymentMethod);
			return model;
		}

		public void EditPaymentMethod(PaymentMethodEditViewModel model)
		{
			var paymentMethod = Mapper.Map<Domains.DataObject.PaymentMethod>(model);
			_dbContext.Entry(paymentMethod).State = System.Data.Entity.EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public PaymentMethodDetailsViewModel BuildPaymentMethodDetailsViewModel(int paymentMethodId)
		{
			var paymentMethod = _dbContext.PaymentMethods.Find(paymentMethodId);
			var model = Mapper.Map<PaymentMethodDetailsViewModel>(paymentMethod);
			return model;
		}

		public PaymentMethodDeleteViewModel BuildPaymentMethodDeleteViewModel(int paymentMethodId)
		{
			var paymentMethod = _dbContext.PaymentMethods.Find(paymentMethodId);
			var model = Mapper.Map<PaymentMethodDeleteViewModel>(paymentMethod);
			return model;
		}

		public void DeletePaymentMethod(int paymentMethodId)
		{
			var paymentMethod = _dbContext.PaymentMethods.Find(paymentMethodId);
			_dbContext.PaymentMethods.Remove(paymentMethod);
			_dbContext.SaveChanges();
		}
	}
}
using MyCashFlow.Web.ViewModels.PaymentMethod;

namespace MyCashFlow.Web.Services.PaymentMethod
{
	public interface IPaymentMethodService
	{
		PaymentMethodIndexViewModel BuildPaymentMethodIndexViewModel(int userId);
		PaymentMethodCreateViewModel BuildPaymentMethodCreateViewModel(string previousUrl);
		void CreatePaymentMethod(PaymentMethodCreateViewModel model);
		PaymentMethodEditViewModel BuildPaymentMethodEditViewModel(int paymentMethodId);
		void EditPaymentMethod(PaymentMethodEditViewModel model);
		PaymentMethodDetailsViewModel BuildPaymentMethodDetailsViewModel(int paymentMethodId);
		PaymentMethodDeleteViewModel BuildPaymentMethodDeleteViewModel(int paymentMethodId);
		void DeletePaymentMethod(int paymentMethodId);
	}
}

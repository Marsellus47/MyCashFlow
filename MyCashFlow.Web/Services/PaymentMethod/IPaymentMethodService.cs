using MyCashFlow.Web.ViewModels.PaymentMethod;

namespace MyCashFlow.Web.Services.PaymentMethod
{
	public interface IPaymentMethodService
	{
		PaymentMethodCreateViewModel BuildPaymentMethodCreateViewModel(string previousUrl);
		void CreatePaymentMethod(PaymentMethodCreateViewModel model);
	}
}

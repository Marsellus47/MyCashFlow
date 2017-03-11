using MyCashFlow.Web.ViewModels.TransactionType;

namespace MyCashFlow.Web.Services.TransactionType
{
	public interface ITransactionTypeService
	{
		TransactionTypeCreateViewModel BuildTransactionTypeCreateViewModel(string previousUrl);
		void CreateTransactionType(TransactionTypeCreateViewModel model);
	}
}

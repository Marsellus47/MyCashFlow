using MyCashFlow.Web.ViewModels.TransactionType;

namespace MyCashFlow.Web.Services.TransactionType
{
	public interface ITransactionTypeService
	{
		TransactionTypeIndexViewModel BuildTransactionTypeIndexViewModel(int userId);
		TransactionTypeCreateViewModel BuildTransactionTypeCreateViewModel(string previousUrl);
		void CreateTransactionType(TransactionTypeCreateViewModel model);
		TransactionTypeEditViewModel BuildTransactionTypeEditViewModel(int transactionTypeId);
		void EditTransactionType(TransactionTypeEditViewModel model);
		TransactionTypeDetailsViewModel BuildTransactionTypeDetailsViewModel(int transactionTypeId);
		TransactionTypeDeleteViewModel BuildTransactionTypeDeleteViewModel(int transactionTypeId);
		void DeleteTransactionType(int transactionTypeId);
	}
}

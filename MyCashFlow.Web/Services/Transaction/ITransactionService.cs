using MyCashFlow.Web.ViewModels.Transaction;

namespace MyCashFlow.Web.Services.Transaction
{
	public interface ITransactionService
	{
		TransactionIndexViewModel BuildTransactionIndexViewModel(int userId, int? projectId);
		TransactionCreateViewModel BuildTransactionCreateViewModel(int userId, int? projectId);
		void CreateTransaction(TransactionCreateViewModel model);
		TransactionEditViewModel BuildTransactionEditViewModel(int userId, int transactionId);
		void EditTransaction(TransactionEditViewModel model);
		TransactionDetailsViewModel BuildTransactionDetailsViewModel(int transactionId);
		TransactionDeleteViewModel BuildTransactionDeleteViewModel(int transactionId);
		void DeleteTransaction(int transactionId);
	}
}

using MyCashFlow.Web.ViewModels.Transaction;

namespace MyCashFlow.Web.Services.Transaction
{
	public interface ITransactionService
	{
		TransactionIndexViewModel BuildTransactionIndexViewModel(int userId, int? projectId);
	}
}

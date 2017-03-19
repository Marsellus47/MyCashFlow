using MyCashFlow.Web.ViewModels.Transaction;
using System.Collections.Generic;

namespace MyCashFlow.Web.Services.Transaction
{
	public interface IApiTransactionService
	{
		IEnumerable<TransactionIndexItemViewModel> GetAll(int userId, int? projectId);
		void Delete(int id);
	}
}

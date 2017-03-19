using MyCashFlow.Web.ViewModels.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCashFlow.Web.Services.Transaction
{
	public interface IApiTransactionService
	{
		Task<IEnumerable<TransactionIndexItemViewModel>> GetAllAsync(int userId, int? projectId);
		Task<TransactionDetailsViewModel> GetAsync(int id);
		Task<TransactionIndexItemViewModel> Create(TransactionCreateViewModel model);
		Task Edit(TransactionEditViewModel model);
		Task DeleteAsync(int id);
	}
}

using System.Collections.Generic;

namespace MyCashFlow.Web.Services.Transaction
{
	public interface IApiTransactionService
	{
		IEnumerable<Domains.DataObject.Transaction> GetAll(int? userId, int? projectId);
	}
}

using MyCashFlow.Domains.DataObject;
using MyCashFlow.Repositories.Repository;

namespace MyCashFlow.Repositories
{
	public interface IUnitOfWork
	{
		IReadOnlyRepository<Country> CountryReppsitory { get; }
		IRepository<Project> ProjectReppsitory { get; }
		IRepository<Transaction> TransactionReppsitory { get; }
		void Save();
	}
}

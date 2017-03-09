using MyCashFlow.Domains.DataObject;
using MyCashFlow.Repositories.Repository;

namespace MyCashFlow.Repositories
{
	public interface IUnitOfWork
	{
		IReadOnlyRepository<Country> CountryRepository { get; }
		IRepository<Project> ProjectRepository { get; }
		IRepository<Transaction> TransactionRepository { get; }
		IRepository<TransactionType> TransactionTypeRepository { get; }
		IRepository<PaymentType> PaymentTypeRepository { get; }
		void Save();
	}
}

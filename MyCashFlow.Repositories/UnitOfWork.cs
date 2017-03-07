using MyCashFlow.Domains.DataObject;
using MyCashFlow.Identity.Context;
using MyCashFlow.Repositories.Repository;
using System;

namespace MyCashFlow.Repositories
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private bool disposed = false;
		private ApplicationDbContext _context;
		private IReadOnlyRepository<Country> _countryRepository;
		private IRepository<Project> _projectRepository;
		private IRepository<Transaction> _transactionRepository;

		public UnitOfWork(
			ApplicationDbContext context,
			IReadOnlyRepository<Country> countryRepository,
			IRepository<Project> projectRepository,
			IRepository<Transaction> transactionRepository)
		{
			if(context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
			if (countryRepository == null)
			{
				throw new ArgumentNullException(nameof(countryRepository));
			}
			if (projectRepository == null)
			{
				throw new ArgumentNullException(nameof(projectRepository));
			}
			if (transactionRepository == null)
			{
				throw new ArgumentNullException(nameof(transactionRepository));
			}

			_context = context;
			_countryRepository = countryRepository;
			_projectRepository = projectRepository;
			_transactionRepository = transactionRepository;
		}

		public IReadOnlyRepository<Country> CountryRepository
		{
			get { return _countryRepository; }
		}

		public IRepository<Project> ProjectRepository
		{
			get { return _projectRepository; }
		}

		public IRepository<Transaction> TransactionRepository
		{
			get { return _transactionRepository; }
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}

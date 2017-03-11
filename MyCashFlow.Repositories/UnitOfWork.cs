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
		private IRepository<TransactionType> _transactionTypeRepository;
		private IRepository<PaymentMethod> _paymentMethodRepository;

		public UnitOfWork(
			ApplicationDbContext context,
			IReadOnlyRepository<Country> countryRepository,
			IRepository<Project> projectRepository,
			IRepository<Transaction> transactionRepository,
			IRepository<TransactionType> transactionTypeRepository,
			IRepository<PaymentMethod> paymentMethodRepository)
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
			if (transactionTypeRepository == null)
			{
				throw new ArgumentNullException(nameof(transactionTypeRepository));
			}
			if (paymentMethodRepository == null)
			{
				throw new ArgumentNullException(nameof(paymentMethodRepository));
			}

			_context = context;
			_countryRepository = countryRepository;
			_projectRepository = projectRepository;
			_transactionRepository = transactionRepository;
			_transactionTypeRepository = transactionTypeRepository;
			_paymentMethodRepository = paymentMethodRepository;
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

		public IRepository<TransactionType> TransactionTypeRepository
		{
			get { return _transactionTypeRepository; }
		}

		public IRepository<PaymentMethod> PaymentMethodRepository
		{
			get { return _paymentMethodRepository; }
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

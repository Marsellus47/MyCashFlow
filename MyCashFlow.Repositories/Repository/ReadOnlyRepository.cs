using MyCashFlow.Identity.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System;

namespace MyCashFlow.Repositories.Repository
{
	public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
		where TEntity : class
	{
		private bool disposed = false;
		
		protected DbSet<TEntity> DbSet;

		protected ApplicationDbContext Context { get; private set; }

		public ReadOnlyRepository(ApplicationDbContext context)
		{
			if(context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			Context = context;
			DbSet = Context.Set<TEntity>();
		}

		public IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = DbSet;

			if(filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if(orderBy != null)
			{
				return orderBy(query).ToList();
			}
			else
			{
				return query.ToList();
			}
		}

		public TEntity GetByID(object id)
		{
			return DbSet.Find(id);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
			{
				if (disposing)
				{
					Context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}

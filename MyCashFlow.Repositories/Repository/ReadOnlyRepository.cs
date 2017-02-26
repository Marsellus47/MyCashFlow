using MyCashFlow.Repositories.Context;
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

		protected DatabaseContext context;
		protected DbSet<TEntity> dbSet;

		public ReadOnlyRepository(DatabaseContext context)
		{
			this.context = context;
			dbSet = context.Set<TEntity>();
		}

		public IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

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
			return dbSet.Find(id);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
			{
				if (disposing)
				{
					context.Dispose();
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

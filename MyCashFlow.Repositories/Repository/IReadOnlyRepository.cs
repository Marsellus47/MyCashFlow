using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;

namespace MyCashFlow.Repositories.Repository
{
	public interface IReadOnlyRepository<TEntity> : IDisposable
	{
		TEntity GetByID(object id);

		IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");
	}
}

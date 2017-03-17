using MyCashFlow.Identity.Context;
using System.Data.Entity;

namespace MyCashFlow.Repositories.Repository
{
	public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity>
		where TEntity : class
	{

		public Repository(IUnitOfWork unitOfWork)
			: base(unitOfWork) { }

		public void Insert(TEntity record)
		{
			DbSet.Add(record);
		}

		public void Update(TEntity record)
		{
			DbSet.Attach(record);
			Context.Entry(record).State = EntityState.Modified;
		}

		public void Delete(object id)
		{
			TEntity record = DbSet.Find(id);
			Delete(record);
		}

		public void Delete(TEntity record)
		{
			if(Context.Entry(record).State == EntityState.Detached)
			{
				DbSet.Attach(record);
			}
			DbSet.Remove(record);
		}
	}
}

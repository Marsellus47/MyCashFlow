using MyCashFlow.Identity.Context;
using System.Data.Entity;

namespace MyCashFlow.Repositories.Repository
{
	public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity>
		where TEntity : class
	{
		public Repository(ApplicationDbContext context) : base(context) { }

		public void Insert(TEntity record)
		{
			dbSet.Add(record);
		}

		public void Update(TEntity record)
		{
			dbSet.Attach(record);
			context.Entry(record).State = EntityState.Modified;
		}

		public void Delete(object id)
		{
			TEntity record = dbSet.Find(id);
			Delete(record);
		}

		public void Delete(TEntity record)
		{
			if(context.Entry(record).State == EntityState.Detached)
			{
				dbSet.Attach(record);
			}
			dbSet.Remove(record);
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}

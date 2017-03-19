using MyCashFlow.Identity.Context;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System;

namespace MyCashFlow.Repositories.Repository
{
	public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity>
		where TEntity : class
	{

		public Repository(ApplicationDbContext context)
			: base(context) { }

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

		public TEntity GetOriginal(TEntity updatedEntity)
		{
			Func<DbPropertyValues, Type, object> getOriginal = null;
			getOriginal = (originalValues, type) =>
			{
				object original = Activator.CreateInstance(type, true);
				foreach (var ptyName in originalValues.PropertyNames)
				{
					var property = type.GetProperty(ptyName);
					object value = originalValues[ptyName];
					if (value is DbPropertyValues) //nested complex object
					{
						property.SetValue(original, getOriginal(value as DbPropertyValues, property.PropertyType));
					}
					else
					{
						property.SetValue(original, value);
					}
				}
				return original;
			};
			return (TEntity)getOriginal(Context.Entry(updatedEntity).GetDatabaseValues(), typeof(TEntity));
		}
	}
}

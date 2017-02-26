namespace MyCashFlow.Repositories.Repository
{
	public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
	{
		void Insert(TEntity record);
		void Update(TEntity record);
		void Delete(object id);
		void Delete(TEntity record);
		void Save();
	}
}

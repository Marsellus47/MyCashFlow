namespace MyCashFlow.Identity.Context
{
	public interface IUnitOfWork
	{
		/// <summary>
		/// Saves changes to all objects that have changed within the unit of work.
		/// </summary>
		void Commit();
	}
}

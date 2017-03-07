using MyCashFlow.Web.ViewModels.Project;

namespace MyCashFlow.Web.Services.Project
{
	public interface IProjectService
	{
		/// <summary>
		/// Build View model needed by Index view in Project controller
		/// </summary>
		/// <param name="userId">Internal ID of the user whose Projects are needed</param>
		/// <returns></returns>
		ProjectIndexViewModel BuildProjectIndexViewModel(int userId);

		/// <summary>
		/// Insert the Project
		/// </summary>
		/// <param name="model">View model containing Project's data</param>
		void CreateProject(ProjectCreateViewModel model);

		/// <summary>
		/// Build View model needed by Edit view in Project controller
		/// </summary>
		/// <param name="projectId">Internal ID of the Project</param>
		/// <returns></returns>
		ProjectEditViewModel BuildProjectEditViewModel(int projectId);

		/// <summary>
		/// Update the Project
		/// </summary>
		/// <param name="model">View model containing Project's data</param>
		void EditProject(ProjectEditViewModel model);

		/// <summary>
		/// Build View model needed by Delete view in Project controller
		/// </summary>
		/// <param name="projectId">Internal ID of the Project</param>
		/// <returns></returns>
		ProjectDeleteViewModel BuildProjectDeleteViewModel(int projectId);

		/// <summary>
		/// Delete the Project
		/// </summary>
		/// <param name="id">Internal ID of the Project</param>
		/// <param name="includingTransactions">Determines if Project Transactions need to be delete or only unliked from Project</param>
		void DeleteProject(int id, bool includingTransactions);
	}
}

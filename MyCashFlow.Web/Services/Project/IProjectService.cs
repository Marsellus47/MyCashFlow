using MyCashFlow.Web.ViewModels.Project;

namespace MyCashFlow.Web.Services.Project
{
	public interface IProjectService
	{
		ProjectIndexViewModel BuildProjectIndexViewModel(int userId);
		void CreateProject(ProjectCreateViewModel model);
		ProjectEditViewModel BuildProjectEditViewModel(int projectId);
		void EditProject(ProjectEditViewModel model);
		ProjectDeleteViewModel BuildProjectDeleteViewModel(int projectId);
	}
}

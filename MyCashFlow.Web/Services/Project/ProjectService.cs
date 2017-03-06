using AutoMapper;
using MyCashFlow.Repositories;
using MyCashFlow.Web.ViewModels.Project;
using Rsx = MyCashFlow.Resources.Localization.Views;
using System.Collections.Generic;
using System;

namespace MyCashFlow.Web.Services.Project
{
	public class ProjectService : IProjectService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProjectService(IUnitOfWork unitOfWork)
		{
			if(unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}

			_unitOfWork = unitOfWork;
		}

		public ProjectIndexViewModel BuildProjectIndexViewModel(int userId)
		{
			var projects = _unitOfWork.ProjectReppsitory.Get(filter: (project) => project.CreatorID == userId);
			var items = Mapper.Map<IList<ProjectIndexItemViewModel>>(projects);
			var model = new ProjectIndexViewModel
			{
				Items = items
			};
			return model;
		}

		public void CreateProject(ProjectCreateViewModel model)
		{
			var project = Mapper.Map<Domains.DataObject.Project>(model);
			_unitOfWork.ProjectReppsitory.Insert(project);
			_unitOfWork.Save();
		}

		public ProjectEditViewModel BuildProjectEditViewModel(int projectId)
		{
			var project = _unitOfWork.ProjectReppsitory.GetByID(projectId);
			var model = Mapper.Map<ProjectEditViewModel>(project);
			return model;
		}

		public void EditProject(ProjectEditViewModel model)
		{
			var project = Mapper.Map<Domains.DataObject.Project>(model);
			_unitOfWork.ProjectReppsitory.Update(project);
			_unitOfWork.Save();
		}

		public ProjectDeleteViewModel BuildProjectDeleteViewModel(int projectId)
		{
			var project = _unitOfWork.ProjectReppsitory.GetByID(projectId);
			var model = Mapper.Map<ProjectDeleteViewModel>(project);

			model.DeleteIncludingTransactionsButtonLabel = Rsx.Project.Delete.Button_DeleteIncludingTransactions;
			model.DeleteProjectOnlyButtonLabel = Rsx.Project.Delete.Button_DeleteProjectOnly;

			return model;
		}
	}
}
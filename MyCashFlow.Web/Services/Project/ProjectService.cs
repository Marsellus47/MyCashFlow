using AutoMapper;
using MyCashFlow.Repositories.Repository;
using MyCashFlow.Web.ViewModels.Project;
using System.Collections.Generic;
using System;

namespace MyCashFlow.Web.Services.Project
{
	public class ProjectService : IProjectService
	{
		private readonly IRepository<Domains.DataObject.Project> _projectRepository;

		public ProjectService(IRepository<Domains.DataObject.Project> projectRepository)
		{
			if(projectRepository == null)
			{
				throw new ArgumentNullException(nameof(projectRepository));
			}

			_projectRepository = projectRepository;
		}

		public ProjectIndexViewModel BuildProjectIndexViewModel(int userId)
		{
			var projects = _projectRepository.Get(filter: (project) => project.CreatorID == userId);
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
			_projectRepository.Insert(project);
			_projectRepository.Save();
		}

		public ProjectEditViewModel BuildProjectEditViewModel(int projectId)
		{
			var project = _projectRepository.GetByID(projectId);
			var model = Mapper.Map<ProjectEditViewModel>(project);
			return model;
		}

		public void EditProject(ProjectEditViewModel model)
		{
			var project = Mapper.Map<Domains.DataObject.Project>(model);
			_projectRepository.Update(project);
			_projectRepository.Save();
		}
	}
}
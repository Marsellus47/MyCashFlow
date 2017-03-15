using AutoMapper;
using MyCashFlow.Repositories;
using MyCashFlow.Web.Infrastructure.ProjectsFilter;
using MyCashFlow.Web.ViewModels.Project;
using MyCashFlow.Web.ViewModels.Transaction;
using Rsx = MyCashFlow.Resources.Localization.Views.Project.Delete;
using System.Collections.Generic;
using System;
using System.Linq;

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

		public ProjectIndexViewModel BuildProjectIndexViewModel(int userId, ProjectsFilterType? projectsFilter)
		{
			var projects = _unitOfWork.ProjectRepository.Get(filter: (project) => project.CreatorID == userId);

			if(projectsFilter.HasValue)
			{
				projects = projects.Where(ProjectsFilterTypeResolver.ResolveFilter(projectsFilter.Value));
			}

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
			_unitOfWork.ProjectRepository.Insert(project);
			_unitOfWork.Save();
		}

		public ProjectEditViewModel BuildProjectEditViewModel(int projectId)
		{
			var project = _unitOfWork.ProjectRepository.GetByID(projectId);
			var model = Mapper.Map<ProjectEditViewModel>(project);
			return model;
		}

		public void EditProject(ProjectEditViewModel model)
		{
			var project = Mapper.Map<Domains.DataObject.Project>(model);
			_unitOfWork.ProjectRepository.Update(project);
			_unitOfWork.Save();
		}

		public ProjectDetailsViewModel BuildProjectDetailsViewModel(int projectId)
		{
			var transactions = _unitOfWork.TransactionRepository.Get(x => x.ProjectID == projectId);
			var items = Mapper.Map<IList<TransactionIndexItemViewModel>>(transactions);
			var model = new ProjectDetailsViewModel
			{
				Items = items,
				ProjectID = projectId
			};
			return model;
		}

		public ProjectDeleteViewModel BuildProjectDeleteViewModel(int projectId)
		{
			var project = _unitOfWork.ProjectRepository.GetByID(projectId);
			var model = Mapper.Map<ProjectDeleteViewModel>(project);

			model.DeleteIncludingTransactionsButtonLabel = Rsx.Button_DeleteIncludingTransactions;
			model.DeleteProjectOnlyButtonLabel = Rsx.Button_DeleteProjectOnly;
			model.Message = Rsx.Message;

			return model;
		}

		public void DeleteProject(int id, bool includingTransactions)
		{
			foreach (var transaction in _unitOfWork.TransactionRepository.Get(x => x.ProjectID == id))
			{
				if(includingTransactions)
				{
					_unitOfWork.TransactionRepository.Delete(transaction.TransactionID);
				}
				else
				{
					transaction.Project = null;
					_unitOfWork.TransactionRepository.Update(transaction);
				}
			}

			_unitOfWork.ProjectRepository.Delete(id);
			_unitOfWork.Save();
		}
	}
}
using AutoMapper;
using MyCashFlow.Repositories.Repository;
using MyCashFlow.Web.Infrastructure.ProjectsFilter;
using MyCashFlow.Web.ViewModels.Project;
using MyCashFlow.Web.ViewModels.Transaction;
using Rsx = MyCashFlow.Resources.Localization.Views.Project.Delete;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyCashFlow.Web.Services.Project
{
	public class ProjectService : IProjectService
	{
		private readonly IRepository<Domains.DataObject.Project> _projectRepository;
		private readonly IRepository<Domains.DataObject.Transaction> _transactionRepository;

		public ProjectService(
			IRepository<Domains.DataObject.Project> projectRepository,
			IRepository<Domains.DataObject.Transaction> transactionRepository)
		{
			if(projectRepository == null)
			{
				throw new ArgumentNullException(nameof(projectRepository));
			}
			if (transactionRepository == null)
			{
				throw new ArgumentNullException(nameof(transactionRepository));
			}

			_projectRepository = projectRepository;
			_transactionRepository = transactionRepository;
		}

		public ProjectIndexViewModel BuildProjectIndexViewModel(int userId, ProjectsFilterType? projectsFilter)
		{
			var projects = _projectRepository.Get(filter: (project) => project.CreatorID == userId);

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
			_projectRepository.Insert(project);
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
		}

		public ProjectDetailsViewModel BuildProjectDetailsViewModel(int projectId)
		{
			var transactions = _transactionRepository.Get(x => x.ProjectID == projectId);
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
			var project = _projectRepository.GetByID(projectId);
			var model = Mapper.Map<ProjectDeleteViewModel>(project);

			model.DeleteIncludingTransactionsButtonLabel = Rsx.Button_DeleteIncludingTransactions;
			model.DeleteProjectOnlyButtonLabel = Rsx.Button_DeleteProjectOnly;
			model.Message = Rsx.Message;

			return model;
		}

		public void DeleteProject(int id, bool includingTransactions)
		{
			foreach (var transaction in _transactionRepository.Get(x => x.ProjectID == id))
			{
				if(includingTransactions)
				{
					_transactionRepository.Delete(transaction.TransactionID);
				}
				else
				{
					transaction.Project = null;
					_transactionRepository.Update(transaction);
				}
			}

			_projectRepository.Delete(id);
		}
	}
}
using AutoMapper;
using MyCashFlow.Identity.Context;
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
		private readonly ApplicationDbContext _dbContext;

		public ProjectService(ApplicationDbContext dbContext)
		{
			if(dbContext == null)
			{
				throw new ArgumentNullException(nameof(dbContext));
			}

			_dbContext = dbContext;
		}

		public ProjectIndexViewModel BuildProjectIndexViewModel(int userId, ProjectsFilterType? projectsFilter)
		{
			var projects = _dbContext.Projects.Where(project => project.CreatorID == userId);

			if(projectsFilter.HasValue)
			{
				projects = projects.Where(ProjectsFilterTypeResolver.ResolveFilter(projectsFilter.Value)).AsQueryable();
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
			_dbContext.Projects.Add(project);
			_dbContext.SaveChanges();
		}

		public ProjectEditViewModel BuildProjectEditViewModel(int projectId)
		{
			var project = _dbContext.Projects.Find(projectId);
			var model = Mapper.Map<ProjectEditViewModel>(project);
			return model;
		}

		public void EditProject(ProjectEditViewModel model)
		{
			var project = Mapper.Map<Domains.DataObject.Project>(model);
			_dbContext.Entry(project).State = System.Data.Entity.EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public ProjectDetailsViewModel BuildProjectDetailsViewModel(int projectId)
		{
			var transactions = _dbContext.Transactions.Where(x => x.ProjectID == projectId);
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
			var project = _dbContext.Projects.Find(projectId);
			var model = Mapper.Map<ProjectDeleteViewModel>(project);

			model.DeleteIncludingTransactionsButtonLabel = Rsx.Button_DeleteIncludingTransactions;
			model.DeleteProjectOnlyButtonLabel = Rsx.Button_DeleteProjectOnly;
			model.Message = Rsx.Message;

			return model;
		}

		public void DeleteProject(int id, bool includingTransactions)
		{
			foreach (var transaction in _dbContext.Transactions.Where(x => x.ProjectID == id))
			{
				if(includingTransactions)
				{
					_dbContext.Transactions.Remove(transaction);
				}
				else
				{
					transaction.Project = null;
					_dbContext.Entry(transaction).State = System.Data.Entity.EntityState.Modified;
				}
			}

			var project = _dbContext.Projects.Find(id);
			_dbContext.Projects.Remove(project);
			_dbContext.SaveChanges();
		}
	}
}
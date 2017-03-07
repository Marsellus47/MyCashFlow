using MyCashFlow.Web.Infrastructure.Attributes;
using MyCashFlow.Web.Infrastructure.Controllers;
using MyCashFlow.Web.Services.Project;
using MyCashFlow.Web.ViewModels.Project;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace MyCashFlow.Web.Controllers
{
	public partial class ProjectController : UserManagerBasedController
	{
		private readonly IProjectService _projectService;

		public ProjectController(IProjectService projectService)
		{
			if (projectService == null)
			{
				throw new ArgumentNullException(nameof(projectService));
			}

			_projectService = projectService;
		}

		public virtual async Task<ActionResult> Index()
		{
			var userId = await GetCurrentUserIdAsync();
			var model = _projectService.BuildProjectIndexViewModel(userId);
			return View(model);
		}

		public virtual ActionResult Create()
		{
			return View(new ProjectCreateViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Create(ProjectCreateViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.CreatorID = await GetCurrentUserIdAsync();
			_projectService.CreateProject(model);

			return RedirectToAction(MVC.Project.ActionNames.Index);
		}

		public virtual ActionResult Edit(int id)
		{
			var model = _projectService.BuildProjectEditViewModel(id);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Edit(ProjectEditViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.CreatorID = await GetCurrentUserIdAsync();
			_projectService.EditProject(model);

			return RedirectToAction(MVC.Project.ActionNames.Index);
		}

		public virtual ActionResult Delete(int id)
		{
			var model = _projectService.BuildProjectDeleteViewModel(id);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MultipleButton(Name = "action", Argument = nameof(DeleteIncludingTransactions))]
		public virtual ActionResult DeleteIncludingTransactions(int id)
		{
			_projectService.DeleteProject(id, true);
			return RedirectToAction(MVC.Project.ActionNames.Index);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MultipleButton(Name = "action", Argument = nameof(DeleteProjectOnly))]
		public virtual ActionResult DeleteProjectOnly(int id)
		{
			_projectService.DeleteProject(id, false);
			return RedirectToAction(MVC.Project.ActionNames.Index);
		}
	}
}
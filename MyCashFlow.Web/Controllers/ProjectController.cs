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
			return View();
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
	}
}
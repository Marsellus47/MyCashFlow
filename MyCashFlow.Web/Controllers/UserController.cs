using MyCashFlow.Web.Services;
using MyCashFlow.Web.ViewModels;
using System.Web.Mvc;
using System;

namespace MyCashFlow.Web.Controllers
{
	public partial class UserController : Controller
	{
		private IUserService userService;

		public UserController(IUserService userService)
		{
			if (userService == null)
			{
				throw new ArgumentNullException(nameof(userService));
			}

			this.userService = userService;
		}

		public virtual ActionResult Index()
		{
			var users = userService.GetAllUsers();
			return View(users);
		}

		public virtual ActionResult Details(int id)
		{
			var user = userService.GetUser(id);
			return View(user);
		}

		public virtual ActionResult Modify(int? id = null)
		{
			var model = userService.BuildUserVm(id);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Modify(UserVm userVm)
		{
			try
			{
				userService.InsertUpdateUser(userVm);
				return RedirectToAction(MVC.User.ActionNames.Index);
			}
			catch
			{
				return RedirectToAction(MVC.User.ActionNames.Modify, new { id = userVm.User.ID });
			}
		}

		public virtual ActionResult Delete(int id)
		{
			var user = userService.GetUser(id);
			return View(user);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				userService.DeleteUser(id);
				return RedirectToAction(MVC.User.ActionNames.Index);
			}
			catch
			{
				return View();
			}
		}
	}
}

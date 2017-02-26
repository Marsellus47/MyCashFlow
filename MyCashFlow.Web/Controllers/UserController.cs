using MyCashFlow.Domains.DataObject;
using MyCashFlow.Web.Services;
using System.Web.Mvc;
using System;

namespace MyCashFlow.Web.Controllers
{
	public class UserController : Controller
    {
		private IUserService userService;

		public UserController(IUserService userService)
		{
			if(userService == null)
			{
				throw new ArgumentNullException(nameof(userService));
			}

			this.userService = userService;
		}
		
        public ActionResult Index()
        {
			var users = userService.GetAllUsers();
            return View(users);
        }
		
        public ActionResult Details(int id)
        {
			var user = userService.GetUser(id);
            return View(user);
        }
		
        public ActionResult Create()
        {
            return View();
        }
		
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
				userService.InsertUser(user);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
		
        public ActionResult Edit(int id)
        {
			var user = userService.GetUser(id);
            return View(user);
        }
		
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
				userService.UpdateUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
		
        public ActionResult Delete(int id)
		{
			var user = userService.GetUser(id);
			return View(user);
        }
		
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				userService.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

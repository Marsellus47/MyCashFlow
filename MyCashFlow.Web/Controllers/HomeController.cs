using System.Web.Mvc;

namespace MyCashFlow.Web.Controllers
{
	public partial class HomeController : Controller
	{
		public virtual ActionResult Index()
		{
			return RedirectToAction(MVC.Project.ActionNames.Index, MVC.Project.Name);
		}
	}
}
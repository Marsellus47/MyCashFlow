using System.Web.Mvc;

namespace MyCashFlow.Web.Controllers
{
	public partial class HomeController : Controller
	{
		public virtual ActionResult Index()
		{
			return Content("Welcome Home");
		}
	}
}
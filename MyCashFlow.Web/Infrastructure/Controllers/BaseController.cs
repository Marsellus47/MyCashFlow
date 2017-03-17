using MyCashFlow.Identity.Context;
using Ninject;
using System.Web.Mvc;

namespace MyCashFlow.Web.Infrastructure.Controllers
{
	public class BaseController : Controller
	{
		[Inject]
		public IUnitOfWork UnitOfWork { get; set; }

		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if(!filterContext.IsChildAction)
			{
				UnitOfWork.Commit();
			}
		}
	}
}
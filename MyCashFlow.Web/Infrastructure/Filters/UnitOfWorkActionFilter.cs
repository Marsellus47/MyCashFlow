using MyCashFlow.Identity.Context;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MyCashFlow.Web.Infrastructure.Filters
{
	public class UnitOfWorkActionFilter : ActionFilterAttribute
	{
		public IUnitOfWork UnitOfWork { get; set; }

		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			UnitOfWork = actionExecutedContext.Request.GetDependencyScope().GetService(typeof(IUnitOfWork)) as IUnitOfWork;
			if(actionExecutedContext.Exception == null)
			{
				UnitOfWork.Commit();
			}
		}
	}
}
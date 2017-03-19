using MyCashFlow.Identity.Context;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MyCashFlow.Web.Infrastructure.Filters
{
	public class UnitOfWorkActionFilter : ActionFilterAttribute
	{
		public ApplicationDbContext Context { get; set; }

		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			Context = actionExecutedContext.Request.GetDependencyScope().GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			if(actionExecutedContext.Exception == null)
			{
				Context.SaveChanges();
			}
		}
	}
}
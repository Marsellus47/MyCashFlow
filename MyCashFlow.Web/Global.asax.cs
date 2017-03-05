using MyCashFlow.Identity.Initializer;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyCashFlow.Web
{
	public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			Database.SetInitializer(new DatabaseInitializer());
        }
    }
}

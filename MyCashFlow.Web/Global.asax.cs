using MyCashFlow.Repositories.Context;
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
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			Database.SetInitializer(new DatabaseInitializer());
        }
    }
}

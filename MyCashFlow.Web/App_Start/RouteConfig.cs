using System.Web.Mvc;
using System.Web.Routing;

namespace MyCashFlow.Web
{
	public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = MVC.Project.Name, action = MVC.Project.ActionNames.Index, id = UrlParameter.Optional }
            );
        }
    }
}

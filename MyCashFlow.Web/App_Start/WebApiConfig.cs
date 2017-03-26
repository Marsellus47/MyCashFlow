using MyCashFlow.Web.Infrastructure.Filters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Http;

namespace MyCashFlow.Web
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Filters.Add(new UnitOfWorkActionFilter());

			var jsonSerializerSettings = new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				PreserveReferencesHandling = PreserveReferencesHandling.All,
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
			config.Formatters.JsonFormatter.SerializerSettings = jsonSerializerSettings;
		}
	}
}
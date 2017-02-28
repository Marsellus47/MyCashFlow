using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyCashFlow.Web.Startup))]

namespace MyCashFlow.Web
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}

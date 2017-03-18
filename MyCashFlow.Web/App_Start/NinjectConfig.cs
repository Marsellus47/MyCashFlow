namespace MyCashFlow.Web
{
	public class NinjectConfig
	{
		public static void RegisterNinject()
		{
			Ninject.Mvc.NinjectContainer.RegisterAssembly();
			Ninject.Http.NinjectHttpContainer.RegisterAssembly();
		}
	}
}
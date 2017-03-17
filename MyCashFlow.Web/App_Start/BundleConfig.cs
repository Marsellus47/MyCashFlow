using System.Web.Optimization;

namespace MyCashFlow.Web
{
	public static class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			// Script bundles
			bundles.Add(new ScriptBundle(Bundles.Scripts.Jquery)
				.Include("~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle(Bundles.Scripts.Jqueryval)
				.Include("~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle(Bundles.Scripts.Modernizr)
				.Include("~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle(Bundles.Scripts.Bootstrap)
				.Include("~/Scripts/bootstrap.min.js",
						 "~/Scripts/respond.js"));

			// Style bundles
			bundles.Add(new StyleBundle(Bundles.Styles.Css).Include(
					"~/Content/bootstrap.css",
					"~/Content/Site.css"));
		}
	}

	public static class Bundles
	{
		public static class Scripts
		{
			public const string Jquery = "~/bundles/jquery";
			public const string Jqueryval = "~/bundles/jqueryval";
			public const string Modernizr = "~/bundles/modernizr";
			public const string Bootstrap = "~/bundles/bootstrap";
		}

		public static class Styles
		{
			public const string Css = "~/Content/css";
		}
	}
}

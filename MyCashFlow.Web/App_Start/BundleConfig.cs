﻿using System.Web.Optimization;

namespace MyCashFlow.Web
{
	public static class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			RegisterScriptBundles(bundles);
			RegisterStyleBundles(bundles);
		}

		private static void RegisterScriptBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle(Bundles.Scripts.Jquery)
				.Include("~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle(Bundles.Scripts.Jqueryval)
				.Include("~/Scripts/jquery.validate.js",
						 "~/Scripts/jquery.validate.unobtrusive.js",
						 "~/Scripts/jquery.unobtrusive-ajax.js"));

			bundles.Add(new ScriptBundle(Bundles.Scripts.JqueryUi)
				.Include("~/Scripts/jquery-ui-{version}.js"));

			bundles.Add(new ScriptBundle(Bundles.Scripts.Modernizr)
				.Include("~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle(Bundles.Scripts.Bootstrap)
				.Include("~/Scripts/bootstrap.min.js",
						 "~/Scripts/respond.js"));

			bundles.Add(new ScriptBundle(Bundles.Scripts.Knockout)
				.Include("~/Scripts/knockout-{version}.js",
						 "~/Scripts/moment-with-locales.min.js")
				.IncludeDirectory("~/Scripts/MyCashFlow/Knockout", "*.js", true));

			bundles.Add(new ScriptBundle(Bundles.Scripts.MyCashFlow.Models.Shared)
				.Include("~/Scripts/MyCashFlow/Models/Shared/*.js"));

			bundles.Add(new ScriptBundle(Bundles.Scripts.MyCashFlow.Models.Transaction)
				.Include("~/Scripts/MyCashFlow/Models/Transaction/*.js"));
		}

		private static void RegisterStyleBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle(Bundles.Styles.Css).Include(
					"~/Content/bootstrap.css",
					"~/Content/Site.css"));

			bundles.Add(new StyleBundle(Bundles.Styles.JqueryUi).Include(
					"~/Content/themes/base/jquery-ui.min.css"));
		}
	}

	public static class Bundles
	{
		public static class Scripts
		{
			public const string Jquery = "~/bundles/jquery";
			public const string Jqueryval = "~/bundles/jqueryval";
			public const string JqueryUi = "~/bundles/jqueryui";
			public const string Modernizr = "~/bundles/modernizr";
			public const string Bootstrap = "~/bundles/bootstrap";
			public const string Knockout = "~/bundles/knockout";

			public static class MyCashFlow
			{
				public static class Models
				{
					public const string Shared = "~/bundles/MyCashFlow/Models/Shared";
					public const string Transaction = "~/bundles/MyCashFlow/Models/Transaction";
				}
			}
		}

		public static class Styles
		{
			public const string Css = "~/Content/css";
			public const string JqueryUi = "~/Content/jqueryui";
		}
	}
}
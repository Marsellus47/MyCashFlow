﻿using System.Web.Mvc;

namespace MyCashFlow.Web
{
	public static class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new AuthorizeAttribute());
		}
	}
}
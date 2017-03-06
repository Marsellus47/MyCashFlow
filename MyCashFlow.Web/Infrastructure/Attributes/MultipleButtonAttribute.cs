using System.Reflection;
using System.Web.Mvc;
using System;

namespace MyCashFlow.Web.Infrastructure.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class MultipleButtonAttribute : ActionNameSelectorAttribute
	{
		public string Name { get; set; }
		public string Argument { get; set; }

		public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
		{
			var isValid = false;
			var keyValue = $"{Name}:{Argument}";
			var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

			if(value != null)
			{
				controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
				isValid = true;
			}

			return isValid;
		}
	}
}
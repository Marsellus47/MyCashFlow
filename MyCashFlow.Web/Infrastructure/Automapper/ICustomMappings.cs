﻿using AutoMapper;

namespace MyCashFlow.Web.Infrastructure.Automapper
{
	/// <summary>
	/// In case complex mapping is required through this option you can create custom mapping rules
	/// </summary>
	public interface IHaveCustomMappings
	{
		void CreateMappings(IMapperConfigurationExpression configuration);
	}
}

﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OptiMinds.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			//services.AddMediatR(typeof(DependencyInjection).Assembly);
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
			return services;
		}
	}
}

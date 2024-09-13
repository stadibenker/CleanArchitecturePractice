﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClearArchitecture.Application
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			return services;
		}
	}
}

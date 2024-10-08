﻿using CleanArchitecture.Infrastructure.EmailService;
using CleanArchitecture.Infrastructure.Logging;
using ClearArchitecture.Application.Contracts.Email;
using ClearArchitecture.Application.Contracts.Logging;
using ClearArchitecture.Application.Models.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

			return services;
		}
	}
}

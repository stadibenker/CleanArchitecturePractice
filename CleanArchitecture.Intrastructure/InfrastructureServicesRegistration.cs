using CleanArchitecture.Infrastructure.EmailService;
using ClearArchitecture.Application.Contracts.Email;
using ClearArchitecture.Application.Models.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection ConfigureInfrastructuionServices (this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailSender, EmailSender>();
			
			return services;
		}
	}
}

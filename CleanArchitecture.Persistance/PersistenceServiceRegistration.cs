using CleanArchitecture.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<HrDbContext>(opt => {
				opt.UseSqlServer(config.GetConnectionString("HrDbConnectionString");
			});
			
			return services;
		}
	}
}

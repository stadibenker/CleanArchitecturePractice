using ClearArchitecture.Application.Contracts.Identity;
using ClearArchitecture.Application.Models.Identity;
using ClearArchitecture.Identity.DbContext;
using ClearArchitecture.Identity.Models;
using ClearArchitecture.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClearArchitecture.Identity
{
	public static class IdentityServicesRegistration
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
		{
			services.Configure<JwtSettings>(config.GetSection("JwtSettings"));

			services.AddDbContext<HrLeaveManagementIdentityDbContext>(options => {
				options.UseSqlServer(config.GetConnectionString("HrDbConnectionString"));
			});

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<HrLeaveManagementIdentityDbContext>()
				.AddDefaultTokenProviders();

			services.AddTransient<IAuthService, AuthService>();
			services.AddTransient<IUserService, UserService>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero,
					ValidIssuer = config["JwtSettings:Issuer"],
					ValidAudience = config["JwtSettings:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]))
				};
			});

			return services;
		}
	}
}

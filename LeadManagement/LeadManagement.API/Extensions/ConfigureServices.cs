using LeadManagement.Application.Interfaces;
using LeadManagement.Application.Interfaces.Repositories;
using LeadManagement.Infrastructure.Data;
using LeadManagement.Infrastructure.Repositories;
using LeadManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LeadManagement.API.Extensions
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddApplicationServices(
			 this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
		{
			{
				if (environment.IsProduction())
				{
					services.AddDbContext<LeadContext>(options =>
						options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
				}
				else
				{
					services.AddDbContext<LeadContext>(options =>
						options.UseSqlite("DataSource=leadmanagement.db"));
				}

				services.AddScoped<IEventRepository, EventRepository>();
				services.AddScoped<ILeadRepository, LeadRepository>();

				services.AddSingleton<IEmailService, EmailService>();

				services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

				return services;
			}
		}
	}
}

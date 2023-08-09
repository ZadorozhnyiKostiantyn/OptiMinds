using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Infrastructure.Cors;
using OptiMinds.Infrastructure.Persistance;

namespace OptiMinds.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
		{
			var CorsPolicySettings = new CorsPolicySettings();
			configuration.Bind(CorsPolicySettings.SectionName, CorsPolicySettings);
			services.AddSingleton(Options.Create(CorsPolicySettings));

			services.AddCors(options =>
			{

				options.AddPolicy(name: CorsPolicySettings.SectionName, policy =>
				{
					policy
					.WithOrigins(CorsPolicySettings.AllowOrigns)
					.WithHeaders(CorsPolicySettings.AllowHeaders)
					.WithMethods(CorsPolicySettings.AllowMethods);
				});
			});

			services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
			services.AddData(configuration);
			return services;
		}

		public static IServiceCollection AddData(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.AddScoped<ApplicationDbContext>();
			services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

			services.AddDbContextPool<ApplicationDbContext>(options =>
				options.UseMySql(
					configuration.GetConnectionString("MySqlConnection"),
					ServerVersion.AutoDetect(configuration.GetConnectionString("MySqlConnection")))
			);

			return services;
		}
	}
}

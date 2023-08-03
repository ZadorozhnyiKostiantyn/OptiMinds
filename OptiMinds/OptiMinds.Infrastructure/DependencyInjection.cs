using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Infrastructure.Persistance;

namespace OptiMinds.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
		{
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

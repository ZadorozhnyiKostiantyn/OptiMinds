using Microsoft.AspNetCore.Mvc.Infrastructure;
using OptiMinds.Api.Common.Errors;
using OptiMinds.Api.Common.Mapping;

namespace OptiMinds.Api;

public static class DependencyInjection
{
	public static IServiceCollection AddPresentation(this IServiceCollection services)
	{
		services.AddControllers();
		services.AddSwaggerGen();
		services.AddCors(options =>
		{
			options.AddPolicy("CorsPolicy", policy =>
			{
				policy.WithOrigins("*");
				policy.WithMethods("GET", "POST", "PUT", "DELETE");
				policy.WithHeaders("*");
			});
		});
		services.AddSingleton<ProblemDetailsFactory, OptiMindsProblemDetailsFactory>();
		services.AddMapping();
		return services;
	}
}

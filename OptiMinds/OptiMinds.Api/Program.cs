using OptiMinds.Api;
using OptiMinds.Application;
using OptiMinds.Infrastructure;
using OptiMinds.Infrastructure.Cors;
using OptiMinds.Infrastructure.Persistance;


var builder = WebApplication.CreateBuilder(args);
{
	// Add services to the container.
	builder.Services
		.AddPresentation()
		.AddApplication()
		.AddInfrastructure(builder.Configuration);

}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(CorsPolicySettings.SectionName);

app.UseAuthorization();

app.MapControllers();

app.DbInitialize();

app.Run();

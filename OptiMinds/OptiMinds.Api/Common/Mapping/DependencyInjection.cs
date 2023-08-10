using Mapster;
using MapsterMapper;
using OptiMinds.Application.Employees.Commands.AddEmployee;
using OptiMinds.Application.ProjectLogs.Commands.CreateProjectLog;
using OptiMinds.Application.Projects.Commands.CreateProject;
using OptiMinds.Application.ProjectTasks.Commands.CreateProjectTask;
using OptiMinds.Application.ProjectTasks.Commands.UpdateProjectTask;
using OptiMinds.Contracts.DTOs.Requests.Employee;
using OptiMinds.Contracts.DTOs.Requests.Project;
using OptiMinds.Contracts.DTOs.Requests.ProjectLog;
using OptiMinds.Contracts.DTOs.Requests.ProjectTask;
using OptiMinds.Contracts.DTOs.Responses.Employee;
using OptiMinds.Contracts.DTOs.Responses.ProjectLog;
using OptiMinds.Contracts.DTOs.Responses.Projects;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Enums;
using System.Reflection;

namespace OptiMinds.Api.Common.Mapping
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddMapping(this IServiceCollection services)
		{
			var config = TypeAdapterConfig.GlobalSettings;
			config.Scan(Assembly.GetExecutingAssembly());

			// CreateProjectCommand Configuration 
			config.NewConfig<CreateProjectRequest, CreateProjectCommand>()
				.Map(dest => dest.StartDate, src => DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(src.StartDate)).DateTime)
				.Map(dest => dest.EndDate, src => DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(src.EndDate)).DateTime)
				.Map(dest => dest.OverallStatus, src => Enum.Parse<Status>(src.OverallStatus));

			// CreateProjectTaskCommand Configuration
			config.NewConfig<CreateProjectTaskRequest, CreateProjectTaskCommand>()
				.Map(dest => dest.Status, src => Enum.Parse<Status>(src.Status))
				.Map(dest => dest.Type, src => Enum.Parse<TaskType>(src.Type))
				.Map(dest => dest.Deadline, src => DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(src.Deadline)).DateTime);

			// AddEmployeeCommand Configuration 
			config.NewConfig<AddEmployeeRequest, AddEmployeeCommand>()
				.Map(dest => dest.EmployeeType, src => Enum.Parse<EmployeeType>(src.EmployeeType));

			// CreateProjectLogCommand Configuration
			config.NewConfig<CreateProjectLogRequest, CreateProjectLogCommand>()
				.Map(dest => dest.Type, src => Enum.Parse<LogType>(src.Type))
				.Map(dest => dest.CreationDate, src => DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(src.CreationDate)).DateTime);

			// Project Configuration
			config.NewConfig<Project, GetProjectDto>()
				.Map(dest => dest.StartDate, src => ((DateTimeOffset)src.StartDate).ToUnixTimeSeconds().ToString())
				.Map(dest => dest.EndDate, src => ((DateTimeOffset)src.EndDate).ToUnixTimeMilliseconds().ToString())
				.Map(dest => dest.OverallStatus, src => src.OverallStatus.ToString());

			// Project Task Configuration
			config.NewConfig<ProjectTask, GetProjectTaskDto>()
				.Map(dest => dest.Status, src => src.Status.ToString())
				.Map(dest => dest.Type, src => src.Type.ToString())
				.Map(dest => dest.Deadline, src => ((DateTimeOffset)src.Deadline).ToUnixTimeMilliseconds().ToString());

			// Employee Configuration 
			config.NewConfig<Employee, GetEmployeeDto>()
				.Map(dest => dest.EmployeeType, src => src.EmployeeType.ToString());

			// Project Log Configuration 
			config.NewConfig<ProjectLog, GetProjectLogDto>()
				.Map(dest => dest.Type, src => src.Type.ToString())
				.Map(dest => dest.CreationDate, src => ((DateTimeOffset)src.CreationDate).ToUnixTimeMilliseconds().ToString());

			// UpdateProjectTaskCommand Configuration
			config.NewConfig<UpdateProjectTaskRequest, UpdateProjectTaskCommand>()
				.Map(dest => dest.Status, src => Enum.Parse<Status>(src.Status))
				.Map(dest => dest.Type, src => Enum.Parse<TaskType>(src.Type))
				.Map(dest => dest.Deadline, src => DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(src.Deadline)).DateTime);


			services.AddSingleton(config);
			services.AddScoped<IMapper, ServiceMapper>();
			return services;
		}
	}
}

using ErrorOr;
using MapsterMapper;
using MediatR;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Contracts.DTOs.Responses.Employee;
using OptiMinds.Contracts.DTOs.Responses.ProjectLog;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Errors;

namespace OptiMinds.Application.ProjectLogs.Queries.GetProjectLogs
{
	internal class GetProjectLogsQueryHandler : IRequestHandler<GetProjectLogsQuery, ErrorOr<IList<GetProjectLogDto>>>
	{
		private readonly IRepository<ProjectLog> _projectLogRepository;
		private readonly IRepository<Project> _projectRepository;
		private readonly IRepository<Employee> _employeeRepository;
		private readonly IRepository<EmployeeProject> _employeeProjectRepository;
		private readonly IRepository<ProjectTask> _projectTaskRepository;
		private readonly IMapper _mapper;

		public GetProjectLogsQueryHandler(
			IRepository<ProjectLog> projectLogRepository,
			IRepository<Project> projectRepository,
			IRepository<EmployeeProject> employeeProjectRepository,
			IRepository<Employee> employeeRepository,
			IMapper mapper,
			IRepository<ProjectTask> projectTaskRepository)
		{
			_projectLogRepository = projectLogRepository;
			_projectRepository = projectRepository;
			_employeeProjectRepository = employeeProjectRepository;
			_employeeRepository = employeeRepository;
			_projectTaskRepository = projectTaskRepository;
			_mapper = mapper;
		}

		public async Task<ErrorOr<IList<GetProjectLogDto>>> Handle(GetProjectLogsQuery request, CancellationToken cancellationToken)
		{
			if (await _projectRepository.FirstOrDefaultAsync(p => p.Id == request.ProjectId) is not Project project)
			{
				return Errors.Project.ProjectDontExist;
			}

			var projectLogs = await _projectLogRepository.GetAllAsync();
			var employeeProjects = await _employeeProjectRepository.SearchAsync(e => e.ProjectId == project.Id);

			var projectLogList = employeeProjects.SelectMany(employeeProject =>
			{
				return projectLogs.Where(p => p.EmployeeId == employeeProject.EmployeeId).Select(projectLog =>
				{
					var getProjectLogDto = _mapper.Map<GetProjectLogDto>(projectLog);
					getProjectLogDto.Employee = _mapper.Map<GetEmployeeDto>(_employeeRepository.GetById(projectLog.EmployeeId));
					getProjectLogDto.ProjectTask = _mapper.Map<GetProjectTaskDto>(_projectTaskRepository.GetById(projectLog.ProjectTaskId));
					return getProjectLogDto;
				});
			}).ToList();

			return projectLogList;
		}
	}
}

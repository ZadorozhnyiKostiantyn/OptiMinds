using ErrorOr;
using MapsterMapper;
using MediatR;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Contracts.DTOs.Responses.Employee;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Errors;

namespace OptiMinds.Application.ProjectTasks.Queries.GetProjectTasks
{
	public class GetProjectTasksQueryHandler : IRequestHandler<GetProjectTasksQuery, ErrorOr<IList<GetProjectTaskDto>>>
    {
		private readonly IRepository<Project> _projectRepository;

		private readonly IRepository<ProjectTask> _projectTaskRepository;
        private readonly IRepository<Employee> _employeeRepository;
		private readonly IMapper _mapper;

		public GetProjectTasksQueryHandler(
			IRepository<ProjectTask> projectTaskRepository,
			IRepository<Employee> employeeRepository,
			IRepository<Project> projectRepository,
			IMapper mapper)
		{
			_projectTaskRepository = projectTaskRepository;
			_employeeRepository = employeeRepository;
			_projectRepository = projectRepository;
			_mapper = mapper;
		}

		public async Task<ErrorOr<IList<GetProjectTaskDto>>> Handle(GetProjectTasksQuery request, CancellationToken cancellationToken)
		{
			if (await _projectRepository.FirstOrDefaultAsync(p => p.Id == request.ProjectId) is not Project project)
			{
				return Errors.Project.ProjectDontExist;
			}

			var tasks = await _projectTaskRepository.SearchAsync(task => task.ProjectId == request.ProjectId);

			return tasks.Select(task =>
			{
				var getProjectTaskDto = _mapper.Map<GetProjectTaskDto>(task);
				getProjectTaskDto.Employee = MapTo(_employeeRepository.GetById(task.EmployeeId));
				return getProjectTaskDto;
			}).ToList();
		}

		public GetEmployeeDto? MapTo(Employee? employee)
        {
            if (employee is not null)
            {
				return _mapper.Map<GetEmployeeDto>(employee);
            }

            return null;
        }
	}
}

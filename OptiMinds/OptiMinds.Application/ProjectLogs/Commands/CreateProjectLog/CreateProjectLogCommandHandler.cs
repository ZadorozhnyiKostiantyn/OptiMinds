using ErrorOr;
using MapsterMapper;
using MediatR;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Contracts.DTOs.Responses.ProjectLog;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Errors;

namespace OptiMinds.Application.ProjectLogs.Commands.CreateProjectLog
{
	public class CreateProjectLogCommandHandler : IRequestHandler<CreateProjectLogCommand, ErrorOr<CreateProjectLogDto>>
    {
        private readonly IRepository<ProjectLog> _projectLogRepository;
		private readonly IRepository<ProjectTask> _projectTaskRepository;
		private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

		public CreateProjectLogCommandHandler(
			IRepository<ProjectLog> projectLogRepository,
			IRepository<Employee> employeeRepository,
			IRepository<ProjectTask> projectTaskRepository,
			IMapper mapper)
		{
			_projectLogRepository = projectLogRepository;
			_employeeRepository = employeeRepository;
			_projectTaskRepository = projectTaskRepository;
			_mapper = mapper;
		}

		public async Task<ErrorOr<CreateProjectLogDto>> Handle(CreateProjectLogCommand request, CancellationToken cancellationToken)
        {
            if (await _employeeRepository.FirstOrDefaultAsync(e => e.Id == request.EmployeeId) is not Employee employee)
            {
                return Errors.Employee.EmployeeDontExist;
            }

			if (await _projectTaskRepository.FirstOrDefaultAsync(t => t.Id == request.ProjectTaskId) is not ProjectTask task)
			{
				return Errors.ProjectTask.ProjectTaskDontExist;
			}

            var projectLog = _mapper.Map<ProjectLog>(request);

            await _projectLogRepository.AddAsync(projectLog);

            return new CreateProjectLogDto
            {
                Id = projectLog.Id
            };
        }
    }
}

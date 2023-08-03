using ErrorOr;
using MapsterMapper;
using MediatR;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Errors;

namespace OptiMinds.Application.ProjectTasks.Commands.CreateProjectTask
{
	public class CreateProjectTaskCommandHandler :
        IRequestHandler<CreateProjectTaskCommand, ErrorOr<CreateProjectTaskDto>>
    {
        private readonly IRepository<ProjectTask> _projectTaskRepository;
        private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

		public CreateProjectTaskCommandHandler(
			IRepository<ProjectTask> projectTaskRepository,
			IRepository<Project> projectRepository,
			IRepository<Employee> employeeRepository,
			IMapper mapper)
		{
			_projectTaskRepository = projectTaskRepository;
			_projectRepository = projectRepository;
			_employeeRepository = employeeRepository;
			_mapper = mapper;
		}

		public async Task<ErrorOr<CreateProjectTaskDto>> Handle(CreateProjectTaskCommand request, CancellationToken cancellationToken)
        {
            // Validate the project exist
            if (await _projectRepository.FirstOrDefaultAsync(p => p.Id == request.ProjectId) is null)
            {
                return Errors.Project.ProjectDontExist;
            }

            // Validate the employee exist  
            if (request.EmployeeId != null)
            {
                if (await _employeeRepository.FirstOrDefaultAsync(e => e.Id == request.EmployeeId) is null)
                {
                    return Errors.Employee.EmployeeDontExist;
                }
            }

            var task = _mapper.Map<ProjectTask>(request);

            await _projectTaskRepository.AddAsync(task);

            return new CreateProjectTaskDto
            {
                Id = task.Id,
            };
        }
    }
}

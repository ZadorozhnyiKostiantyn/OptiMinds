using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OptiMinds.Application.Employees.Commands.AddEmployee;
using OptiMinds.Application.ProjectLogs.Commands.CreateProjectLog;
using OptiMinds.Application.ProjectLogs.Queries.GetProjectLogs;
using OptiMinds.Application.Projects.Commands.CreateProject;
using OptiMinds.Application.Projects.Queries.GetProject;
using OptiMinds.Application.ProjectTasks.Commands.CreateProjectTask;
using OptiMinds.Application.ProjectTasks.Commands.DeleteProjectTask;
using OptiMinds.Application.ProjectTasks.Commands.UpdateProjectTask;
using OptiMinds.Application.ProjectTasks.Queries.GetProjectTasks;
using OptiMinds.Contracts.DTOs.Requests.Employee;
using OptiMinds.Contracts.DTOs.Requests.Project;
using OptiMinds.Contracts.DTOs.Requests.ProjectLog;
using OptiMinds.Contracts.DTOs.Requests.ProjectTask;
using OptiMinds.Contracts.DTOs.Responses.Employee;
using OptiMinds.Contracts.DTOs.Responses.ProjectLog;
using OptiMinds.Contracts.DTOs.Responses.Projects;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;

namespace OptiMinds.Api.Controllers
{
	[Route("api/[controller]")]
	public class ProjectController : ApiController
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public ProjectController(
			IMediator mediator,
			IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		// POST

		[HttpPost("/create-project")]
		public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest request)
		{
			var command = _mapper.Map<CreateProjectCommand>(request);

			ErrorOr<CreateProjectDto> createProjectResult = await _mediator.Send(command);

			return createProjectResult.Match(
				createProjectResult => Ok(createProjectResult),
				errors => Problem(errors));
		}

		[HttpPost("/create-project-task")]
		public async Task<IActionResult> CreateProjectTask([FromBody] CreateProjectTaskRequest request)
		{
			var command = _mapper.Map<CreateProjectTaskCommand>(request);

			ErrorOr<CreateProjectTaskDto> createProjectTaskResult = await _mediator.Send(command);

			return createProjectTaskResult.Match(
				createProjectTaskResult => Ok(createProjectTaskResult),
				errors => Problem(errors));
		}

		[HttpPost("/add-employee")]
		public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
		{

			var command = _mapper.Map<AddEmployeeCommand>(request);

			ErrorOr<AddEmployeeDto> addEmployeeResult = await _mediator.Send(command);

			return addEmployeeResult.Match(
				addEmployeeResult => Ok(addEmployeeResult),
				errors => Problem(errors));
		}

		[HttpPost("/create-project-log")]
		public async Task<IActionResult> CreateProjectLog([FromBody] CreateProjectLogRequest request)
		{
			var command = _mapper.Map<CreateProjectLogCommand>(request);

			ErrorOr<CreateProjectLogDto> projectLogCreationResult = await _mediator.Send(command);

			return projectLogCreationResult.Match(
				projectLogCreationResult => Ok(projectLogCreationResult),
				errors => Problem(errors));
		}

		// GET

		[HttpGet("/get-project/{id}")]
		public async Task<IActionResult> GetProject(int id)
		{
			var query = new GetProjectQuery(id);
			ErrorOr<GetProjectDto> getProjectResult = await _mediator.Send(query);

			return getProjectResult.Match(
				getProjectResult => Ok(getProjectResult),
				errors => Problem(errors));
		}

		[HttpGet("/get-tasks/{projectId}")]
		public async Task<IActionResult> GetProjectTasks(int projectId)
		{
			var query = new GetProjectTasksQuery(projectId);
			ErrorOr<IList<GetProjectTaskDto>> getProjectTasksResult = await _mediator.Send(query);

			return getProjectTasksResult.Match(
				getProjectTasksResult => Ok(getProjectTasksResult),
				errors => Problem(errors));
		}

		[HttpGet("/get-project-logs/{projectId}")]
		public async Task<IActionResult> GetProjectLogs(int projectId)
		{
			var query = new GetProjectLogsQuery(projectId);
			ErrorOr<IList<GetProjectLogDto>> getProjectLogsResult = await _mediator.Send(query);

			return getProjectLogsResult.Match(
				getProjectLogsResult => Ok(getProjectLogsResult),
				errors => Problem(errors));
		}

		// DELETE

		[HttpDelete("/delete-task/{id}")]
		public async Task<IActionResult> DeleteTask(int id)
		{
			var command = new DeleteProjectTaskCommand(id);

			ErrorOr<DeleteProjectTaskDto> projectTaskDeleteResult = await _mediator.Send(command);

			return projectTaskDeleteResult.Match(
				projectTaskDeleteResult => Ok(projectTaskDeleteResult),
				errors => Problem(errors));
		}

		[HttpDelete("/delete-project-log/{id}")]
		public async Task<IActionResult> DeleteProjectLog(int id)
		{
			var command = new DeleteProjectLogCommand(id);

			ErrorOr<DeleteProjectLogDto> projectTaskDeleteResult = await _mediator.Send(command);

			return projectTaskDeleteResult.Match(
				projectTaskDeleteResult => Ok(projectTaskDeleteResult),
				errors => Problem(errors));
		}


		// PUT

		[HttpPut("/update-task")]
		public async Task<IActionResult> UdpateProjectTask([FromBody] UpdateProjectTaskRequest request)
		{
			var command = _mapper.Map<UpdateProjectTaskCommand>(request);

			ErrorOr<UpdateProjectTaskDto> projectTaskUpdateResult = await _mediator.Send(command);

			return projectTaskUpdateResult.Match(
				projectTaskUpdateResult => Ok(projectTaskUpdateResult),
				errors => Problem(errors));
		}
	}
}

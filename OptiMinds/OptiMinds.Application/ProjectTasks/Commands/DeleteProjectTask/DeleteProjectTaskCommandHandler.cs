using ErrorOr;
using MediatR;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Errors;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OptiMinds.Application.ProjectTasks.Commands.DeleteProjectTask
{
	public class DeleteProjectTaskCommandHandler : IRequestHandler<DeleteProjectTaskCommand, ErrorOr<DeleteProjectTaskDto>>
	{
		private readonly IRepository<ProjectTask> _projectTaskRepository;

		public DeleteProjectTaskCommandHandler(IRepository<ProjectTask> projectTaskRepository)
		{
			_projectTaskRepository = projectTaskRepository;
		}

		public async Task<ErrorOr<DeleteProjectTaskDto>> Handle(DeleteProjectTaskCommand request, CancellationToken cancellationToken)
		{
			if (await _projectTaskRepository.FirstOrDefaultAsync(p => p.Id == request.Id) is not ProjectTask task)
			{
				return Errors.ProjectTask.ProjectTaskDontExist;
			}

			await _projectTaskRepository.DeleteAsync(request.Id);

			return new DeleteProjectTaskDto
			{
				Id = request.Id,
			};
		}
	}
}

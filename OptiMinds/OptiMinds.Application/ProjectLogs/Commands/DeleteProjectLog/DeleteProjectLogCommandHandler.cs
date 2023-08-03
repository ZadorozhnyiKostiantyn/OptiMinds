using ErrorOr;
using MediatR;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Contracts.DTOs.Responses.Projects;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Errors;

namespace OptiMinds.Application.ProjectTasks.Commands.DeleteProjectTask
{
	public class DeleteProjectLogCommandHandler :
		IRequestHandler<DeleteProjectLogCommand, ErrorOr<DeleteProjectLogDto>>
	{
		private readonly IRepository<ProjectLog> _projectLogRepository;

		public DeleteProjectLogCommandHandler(IRepository<ProjectLog> projectLogRepository)
		{
			_projectLogRepository = projectLogRepository;
		}

		public async Task<ErrorOr<DeleteProjectLogDto>> Handle(DeleteProjectLogCommand request, CancellationToken cancellationToken)
		{
			if (await _projectLogRepository.FirstOrDefaultAsync(p => p.Id == request.Id) is not ProjectLog log)
			{
				return Errors.ProjectLog.ProjectLogDontExist;
			}

			await _projectLogRepository.DeleteAsync(request.Id);

			return new DeleteProjectLogDto
			{
				Id = request.Id,
			};
		}
	}
}

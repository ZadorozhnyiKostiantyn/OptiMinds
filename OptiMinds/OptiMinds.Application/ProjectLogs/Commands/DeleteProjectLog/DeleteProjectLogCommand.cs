using ErrorOr;
using MediatR;
using OptiMinds.Contracts.DTOs.Responses.Projects;

namespace OptiMinds.Application.ProjectTasks.Commands.DeleteProjectTask
{
	public record DeleteProjectLogCommand(int Id) : IRequest<ErrorOr<DeleteProjectLogDto>>;
}

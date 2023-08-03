using ErrorOr;
using MediatR;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;

namespace OptiMinds.Application.ProjectTasks.Queries.GetProjectTasks
{
	public record GetProjectTasksQuery(int ProjectId) : IRequest<ErrorOr<IList<GetProjectTaskDto>>>;
}

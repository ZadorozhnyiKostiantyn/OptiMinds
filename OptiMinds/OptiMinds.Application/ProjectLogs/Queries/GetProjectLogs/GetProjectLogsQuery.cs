using ErrorOr;
using MediatR;
using OptiMinds.Contracts.DTOs.Responses.ProjectLog;

namespace OptiMinds.Application.ProjectLogs.Queries.GetProjectLogs
{
	public record GetProjectLogsQuery(int ProjectId) : IRequest<ErrorOr<IList<GetProjectLogDto>>>;
}

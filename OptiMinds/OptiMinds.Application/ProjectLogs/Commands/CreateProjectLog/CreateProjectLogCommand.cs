using ErrorOr;
using MediatR;
using OptiMinds.Contracts.DTOs.Responses.ProjectLog;
using OptiMinds.Domain.Enums;

namespace OptiMinds.Application.ProjectLogs.Commands.CreateProjectLog
{
	public record CreateProjectLogCommand(
        LogType Type,
        DateTime CreationDate,
        int EmployeeId,
        int ProjectTaskId) : IRequest<ErrorOr<CreateProjectLogDto>>;
}

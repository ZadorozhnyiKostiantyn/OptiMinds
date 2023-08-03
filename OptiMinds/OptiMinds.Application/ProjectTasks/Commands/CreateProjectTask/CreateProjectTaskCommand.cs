using ErrorOr;
using MediatR;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;
using OptiMinds.Domain.Enums;

namespace OptiMinds.Application.ProjectTasks.Commands.CreateProjectTask
{
	public record CreateProjectTaskCommand(
        string Title,
        Status Status,
        TaskType Type,
        string Description,
        DateTime Deadline,
        float EstimateInHour,
        int? EmployeeId,
        int ProjectId) : IRequest<ErrorOr<CreateProjectTaskDto>>;
}

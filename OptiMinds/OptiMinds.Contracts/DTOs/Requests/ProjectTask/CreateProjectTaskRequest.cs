using OptiMinds.Domain.Enums;

namespace OptiMinds.Contracts.DTOs.Requests.ProjectTask
{
	public record CreateProjectTaskRequest(
		string Title,
		string Status,
		string Type,
		string Description,
		long Deadline,
		float EstimateInHour,
		int? EmployeeId,
		int ProjectId);
}

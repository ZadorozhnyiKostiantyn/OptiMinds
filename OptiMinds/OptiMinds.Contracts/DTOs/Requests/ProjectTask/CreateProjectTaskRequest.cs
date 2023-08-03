using OptiMinds.Domain.Enums;

namespace OptiMinds.Contracts.DTOs.Requests.ProjectTask
{
	public record CreateProjectTaskRequest(
		string Title,
		string Status,
		string Type,
		string Description,
		string Deadline,
		float EstimateInHour,
		int? EmployeeId,
		int ProjectId);
}

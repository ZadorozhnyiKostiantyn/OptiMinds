using OptiMinds.Domain.Enums;

namespace OptiMinds.Contracts.DTOs.Requests.ProjectLog
{
	public record CreateProjectLogRequest(
		string Type,
		string CreationDate,
		int EmployeeId,
		int ProjectTaskId);
}

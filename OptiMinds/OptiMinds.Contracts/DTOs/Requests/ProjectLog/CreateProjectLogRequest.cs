using OptiMinds.Domain.Enums;

namespace OptiMinds.Contracts.DTOs.Requests.ProjectLog
{
	public record CreateProjectLogRequest(
		string Type,
		long CreationDate,
		int EmployeeId,
		int ProjectTaskId);
}

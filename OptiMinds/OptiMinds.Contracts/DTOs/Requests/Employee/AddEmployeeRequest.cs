using OptiMinds.Domain.Enums;

namespace OptiMinds.Contracts.DTOs.Requests.Employee
{
	public record AddEmployeeRequest(
		string FirstName,
		string LastName,
		string EmployeeType,
		int ProjectId);
}

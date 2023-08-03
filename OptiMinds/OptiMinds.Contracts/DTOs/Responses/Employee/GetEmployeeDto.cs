using OptiMinds.Domain.Enums;

namespace OptiMinds.Contracts.DTOs.Responses.Employee
{
	public class GetEmployeeDto
	{
		public int? Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? EmployeeType { get; set; }
	}
}

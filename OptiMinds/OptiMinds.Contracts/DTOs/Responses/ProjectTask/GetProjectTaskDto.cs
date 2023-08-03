using OptiMinds.Contracts.DTOs.Responses.Employee;
using OptiMinds.Domain.Enums;

namespace OptiMinds.Contracts.DTOs.Responses.ProjectTask
{
	public class GetProjectTaskDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Status { get; set; }
		public string Type { get; set; }
		public string Description { get; set; } = null!;
		public string Deadline { get; set; }
		public float EstimateInHour { get; set; }
		public GetEmployeeDto? Employee { get; set; }
	}
}

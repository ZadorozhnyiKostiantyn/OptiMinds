using OptiMinds.Contracts.DTOs.Responses.Employee;
using OptiMinds.Domain.Enums;

namespace OptiMinds.Contracts.DTOs.Responses.Projects
{
	public class GetProjectDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public long? StartDate { get; set; }
		public long? EndDate { get; set; }
		public string? OverallStatus { get; set; }
		public float? TotalBudget { get; set; }
		public float? SpendBudget { get; set; }
	}
}

using OptiMinds.Contracts.DTOs.Responses.Employee;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;
using OptiMinds.Domain.Enums;

namespace OptiMinds.Contracts.DTOs.Responses.ProjectLog
{
	public class GetProjectLogDto
	{
		public int Id { get; set; }
		public string? Type { get; set; }
		public long? CreationDate { get; set; }
		public string Description { get; set; } = null!;
		public GetEmployeeDto Employee { get; set; }
		public GetProjectTaskDto ProjectTask { get; set; }
	}
}

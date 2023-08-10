namespace OptiMinds.Contracts.DTOs.Requests.Project
{
	public record CreateProjectRequest(
		string Name,
		long StartDate,
		long EndDate,
		string OverallStatus,
		float TotalBudget,
		float SpendBudget);
}

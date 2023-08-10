namespace OptiMinds.Contracts.DTOs.Requests.Project
{
	public record CreateProjectRequest(
		string Name,
		string StartDate,
		string EndDate,
		string OverallStatus,
		float TotalBudget,
		float SpendBudget);
}

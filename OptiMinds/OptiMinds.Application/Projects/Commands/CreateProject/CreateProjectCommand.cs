using ErrorOr;
using MediatR;
using OptiMinds.Contracts.DTOs.Responses.Projects;
using OptiMinds.Domain.Enums;

namespace OptiMinds.Application.Projects.Commands.CreateProject
{
	public record CreateProjectCommand(
		string Name,
		DateTime StartDate,
		DateTime EndDate,
		Status OverallStatus,
		float TotalBudget,
		float SpendBudget) : IRequest<ErrorOr<CreateProjectDto>>;
}

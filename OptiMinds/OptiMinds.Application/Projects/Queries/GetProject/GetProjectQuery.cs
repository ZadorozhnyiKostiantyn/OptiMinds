using ErrorOr;
using MediatR;
using OptiMinds.Contracts.DTOs.Responses.Projects;

namespace OptiMinds.Application.Projects.Queries.GetProject
{
	public record GetProjectQuery(int Id) : IRequest<ErrorOr<GetProjectDto>>;
}

using ErrorOr;
using MapsterMapper;
using MediatR;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Contracts.DTOs.Responses.Projects;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Errors;

namespace OptiMinds.Application.Projects.Queries.GetProject
{
	public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ErrorOr<GetProjectDto>>
	{
		private readonly IRepository<Project> _projectRepository;
		private readonly IMapper _mapper;

		public GetProjectQueryHandler(IRepository<Project> projectRepository, IMapper mapper)
		{
			_projectRepository = projectRepository;
			_mapper = mapper;
		}

		public async Task<ErrorOr<GetProjectDto>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
		{
			if (await _projectRepository.FirstOrDefaultAsync(p => p.Id == request.Id) is not Project project)
			{
				return Errors.Project.ProjectDontExist;
			}

			return _mapper.Map<GetProjectDto>(project);
				
		}
	}

}

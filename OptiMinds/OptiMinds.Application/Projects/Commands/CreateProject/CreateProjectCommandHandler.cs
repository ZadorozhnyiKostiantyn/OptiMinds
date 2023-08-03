using ErrorOr;
using MapsterMapper;
using MediatR;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Contracts.DTOs.Responses.Projects;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Errors;

namespace OptiMinds.Application.Projects.Commands.CreateProject
{
	public class CreateProjectCommandHandler :
		 IRequestHandler<CreateProjectCommand, ErrorOr<CreateProjectDto>>
	{
		private readonly IRepository<Project> _projectRepository;
		private readonly IMapper _mapper;

		public CreateProjectCommandHandler(IRepository<Project> projectRepository, IMapper mapper)
		{
			_projectRepository = projectRepository;
			_mapper = mapper;
		}

		async Task<ErrorOr<CreateProjectDto>> IRequestHandler<CreateProjectCommand, ErrorOr<CreateProjectDto>>.Handle(CreateProjectCommand request, CancellationToken cancellationToken)
		{
			if (await _projectRepository.FirstOrDefaultAsync(p => p.Name == request.Name) is not null)
			{
				return Errors.Project.ProjectWithGivenNameIsExist;
			}

			var project = _mapper.Map<Project>(request);

			await _projectRepository.AddAsync(project);

			return new CreateProjectDto
			{
				Id = project.Id
			};
		}
	}
}

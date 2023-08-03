using ErrorOr;
using MapsterMapper;
using MediatR;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Errors;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OptiMinds.Application.ProjectTasks.Commands.UpdateProjectTask
{
	public class UpdateProjectTaskCommandHandler : 
		IRequestHandler<UpdateProjectTaskCommand, ErrorOr<UpdateProjectTaskDto>>
	{
		private readonly IRepository<ProjectTask> _projectTaskRepository;
		private readonly IMapper _mapper;

		public UpdateProjectTaskCommandHandler(IRepository<ProjectTask> prohectTaskRepository, IMapper mapper)
		{
			_projectTaskRepository = prohectTaskRepository;
			_mapper = mapper;
		}

		public async Task<ErrorOr<UpdateProjectTaskDto>> Handle(UpdateProjectTaskCommand request, CancellationToken cancellationToken)
		{
			if (await _projectTaskRepository.FirstOrDefaultAsync(p => p.Id == request.Id) is not ProjectTask task)
			{
				return Errors.ProjectTask.ProjectTaskDontExist;
			}

			await _projectTaskRepository.UpdateAsync(_mapper.Map<ProjectTask>(request));

			return new UpdateProjectTaskDto 
			{ 
				Id = request.Id 
			};

		}
	}
}

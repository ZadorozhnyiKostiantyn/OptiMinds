using ErrorOr;
using MediatR;
using OptiMinds.Contracts.DTOs.Responses.ProjectTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiMinds.Application.ProjectTasks.Commands.DeleteProjectTask
{
	public record DeleteProjectTaskCommand(int Id) : IRequest<ErrorOr<DeleteProjectTaskDto>>;
}

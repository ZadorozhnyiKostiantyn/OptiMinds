using ErrorOr;

namespace OptiMinds.Domain.Errors
{
	public static partial class Errors
	{
		public static class ProjectTask
		{
			public static Error ProjectTaskDontExist = Error.Conflict(
				code: "ProjectTask.ProjectTaskDontExist",
				description: "Task with given id don't exists");
		}
	}
}

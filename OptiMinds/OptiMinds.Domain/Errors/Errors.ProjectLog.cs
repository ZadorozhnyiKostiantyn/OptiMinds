using ErrorOr;

namespace OptiMinds.Domain.Errors
{
	public static partial class Errors
	{
		public static class ProjectLog
		{
			public static Error ProjectLogDontExist = Error.Conflict(
				code: "ProjectLog.ProjectLogDontExist",
				description: "Project Log with given id don't exists");
		}
	}
}

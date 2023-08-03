using ErrorOr;

namespace OptiMinds.Domain.Errors
{
	public static partial class Errors
	{
		public static class Project
		{
			public static Error ProjectDontExist = Error.Conflict(
				code: "Project.ProjectDontExist",
				description: "Project with given id don't exists");

			public static Error ProjectWithGivenNameIsExist = Error.Conflict(
				code: "Project.ProjectWithGivenNameIsExist",
				description: "Project with given name exists");
		}
	}
}

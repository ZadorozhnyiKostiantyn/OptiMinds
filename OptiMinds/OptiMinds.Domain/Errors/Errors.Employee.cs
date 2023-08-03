using ErrorOr;

namespace OptiMinds.Domain.Errors
{
    public static partial class Errors
    {
        public static class Employee
        {
            public static Error EmployeeDontExist = Error.Conflict(
                code: "Employee.EmployeeDontExist",
                description: "Employee with given id don't exists");

			public static Error DuplicateEmployeeName = Error.Conflict(
				code: "Employee.DuplicateEmployeeName",
				description: "Employee with given name already exists");
		}
    }
}

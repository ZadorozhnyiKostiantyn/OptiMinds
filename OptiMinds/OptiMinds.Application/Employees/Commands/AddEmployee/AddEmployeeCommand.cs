using ErrorOr;
using MediatR;
using OptiMinds.Contracts.DTOs.Responses.Employee;
using OptiMinds.Domain.Enums;

namespace OptiMinds.Application.Employees.Commands.AddEmployee
{
    public record AddEmployeeCommand(
        string FirstName,
        string LastName,
        EmployeeType EmployeeType,
        int ProjectId) : IRequest<ErrorOr<AddEmployeeDto>>;
}

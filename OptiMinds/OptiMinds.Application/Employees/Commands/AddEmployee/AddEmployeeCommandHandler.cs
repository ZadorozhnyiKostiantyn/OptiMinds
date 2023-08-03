﻿using ErrorOr;
using MediatR;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Contracts.DTOs.Responses.Employee;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Errors;

namespace OptiMinds.Application.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, ErrorOr<AddEmployeeDto>>
    {
        private readonly IRepository<Employee> _employeeRepository;
		private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<EmployeeProject> _employeeProjectRepository;

		public AddEmployeeCommandHandler(
			IRepository<Employee> employeeRepository,
			IRepository<Project> projectRepository,
			IRepository<EmployeeProject> employeeProjectRepository)
		{
			_employeeRepository = employeeRepository;
			_projectRepository = projectRepository;
			_employeeProjectRepository = employeeProjectRepository;
		}

		public async Task<ErrorOr<AddEmployeeDto>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (await _employeeRepository.FirstOrDefaultAsync(e => e.FirstName == request.FirstName) is not null)
            {
                return Errors.Employee.DuplicateEmployeeName;
            }

			if (await _projectRepository.FirstOrDefaultAsync(e => e.Id == request.ProjectId) is null)
			{
				return Errors.Project.ProjectDontExist;
			}

			var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmployeeType = request.EmployeeType,
            };

            await _employeeRepository.AddAsync(employee);

            await _employeeProjectRepository.AddAsync(new EmployeeProject
			{
				EmployeeId = employee.Id,
				ProjectId = request.ProjectId
			});

            return new AddEmployeeDto
            {
                Id = employee.Id
            };
        }
    }
}

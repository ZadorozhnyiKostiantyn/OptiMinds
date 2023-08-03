using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OptiMinds.Domain.Entities;
using OptiMinds.Domain.Enums;

namespace OptiMinds.Infrastructure.Persistance
{
	public static class DbInitializer
	{
		public static WebApplication DbInitialize(this WebApplication app)
		{
			using (var scope = app.Services.CreateScope())
				try
				{
					var scopedContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
					DbInitializer.Initializer(scopedContext);
				}
				catch
				{
					throw;
				}

			return app;
		}

		public static void Initializer(
			ApplicationDbContext context)
		{
			context.Database.EnsureCreated();
			if (!context.Projects.Any())
			{
				context.Projects.AddRange(new List<Project>()
				{
					new Project
					{
						Name = "datapine",
						StartDate = new DateTime(2017,05,01),
						EndDate = new DateTime(2017,12,15),
						OverallStatus = Status.InProgress,
						TotalBudget = 52_000,
						SpendBudget = 12_000
					}
				});

				context.SaveChanges();
			}

			if(!context.Employees.Any())
			{
				context.Employees.AddRange(new List<Employee>()
				{
					new Employee
					{
						FirstName = "Georg",
						LastName = "Danwill",
						EmployeeType = EmployeeType.ProjectLeader
					},
					new Employee
					{
						FirstName = "Paula",
						LastName = "Dashkov",
						EmployeeType = EmployeeType.Developer
					},
					new Employee
					{
						FirstName = "Catherine",
						LastName = "Redfern",
						EmployeeType = EmployeeType.Developer
					},
					new Employee
					{
						FirstName = "Nancy",
						LastName = "Eyler",
						EmployeeType = EmployeeType.Developer
					},
					new Employee
					{
						FirstName = "Kate",
						LastName = "Bates",
						EmployeeType = EmployeeType.Developer
					},
					new Employee
					{
						FirstName = "Richard",
						LastName = "Patrick",
						EmployeeType = EmployeeType.Developer
					},
				});

				context.SaveChanges();
			}

			if (!context.EmployeeProjects.Any())
			{
				for (int i = 1; i <= 6; i++)
				{
					context.EmployeeProjects.Add(new EmployeeProject
					{
						ProjectId = 1,
						EmployeeId = i,
					});
				}
				context.SaveChanges();
			}

			if (!context.Tasks.Any())
			{
				var random = new Random();
				context.Tasks.AddRange(new List<ProjectTask>()
				{
					// Planning 
					new ProjectTask
					{
						Title = "Planning 1",
						Status = Status.Closed,
						Type = TaskType.Planning,
						Description = "Description 1",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 6,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Planning 2",
						Status = Status.Closed,
						Type = TaskType.Planning,
						Description = "Description 2",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 6,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Planning 3",
						Status = Status.Closed,
						Type = TaskType.Planning,
						Description = "Description 3",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 6,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Planning 4",
						Status = Status.Closed,
						Type = TaskType.Planning,
						Description = "Description 4",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 5,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Planning 5",
						Status = Status.Closed,
						Type = TaskType.Planning,
						Description = "Description 5",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 5,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Planning 6",
						Status = Status.Closed,
						Type = TaskType.Planning,
						Description = "Description 6",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 5,
						ProjectId = 1
					},

					// Design 
					new ProjectTask
					{
						Title = "Design 1",
						Status = Status.Closed,
						Type = TaskType.Design,
						Description = "Description 1",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 6,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Design 2",
						Status = Status.Closed,
						Type = TaskType.Design,
						Description = "Description 2",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 6,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Design 3",
						Status = Status.Closed,
						Type = TaskType.Design,
						Description = "Description 3",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 6,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Design 4",
						Status = Status.Closed,
						Type = TaskType.Design,
						Description = "Description 4",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 5,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Design 5",
						Status = Status.Closed,
						Type = TaskType.Design,
						Description = "Description 5",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 5,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Design 5",
						Status = Status.Closed,
						Type = TaskType.Design,
						Description = "Description 6",
						Deadline = DateTime.Now,
						EstimateInHour = random.Next(5, 20),
						EmployeeId = 5,
						ProjectId = 1
					},


					// Development 
					new ProjectTask
					{
						Title = "Status Update For Board",
						Status = Status.InProgress,
						Type = TaskType.Development,
						Description = "Description to Status Update For Board",
						Deadline = new DateTime(2017, 08, 15),
						EstimateInHour = random.Next(5, 30),
						EmployeeId = 2,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Finish UX Optimizations",
						Status = Status.InProgress,
						Type = TaskType.Development,
						Description = "Description to Finish UX Optimizations",
						Deadline = new DateTime(2017, 08, 12),
						EstimateInHour = random.Next(5, 40),
						EmployeeId = 3,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Configure Mobile View",
						Status = Status.InProgress,
						Type = TaskType.Development,
						Description = "Description to Configure Mobile View",
						Deadline = new DateTime(2017, 08, 06),
						EstimateInHour = random.Next(5, 32),
						EmployeeId = 4,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Relation Database Connecations",
						Status = Status.InProgress,
						Type = TaskType.Development,
						Description = "Description to Relation Database Connecations",
						Deadline = new DateTime(2017, 07, 23),
						EstimateInHour = random.Next(5, 35),
						EmployeeId = 1,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Interactive Dashboard Features",
						Status = Status.InProgress,
						Type = TaskType.Development,
						Description = "Description to Interactive Dashboard Features",
						Deadline = new DateTime(2017, 08, 21),
						EstimateInHour = random.Next(5, 40),
						EmployeeId = 3,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Facebook API Connector",
						Status = Status.InProgress,
						Type = TaskType.Development,
						Description = "Description to Facebook API Connector",
						Deadline = new DateTime(2017, 08, 30),
						EstimateInHour = random.Next(5, 40),
						EmployeeId = 1,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Set-Up Test Environment",
						Status = Status.InProgress,
						Type = TaskType.Development,
						Description = "Description to Set-Up Test Environment",
						Deadline = new DateTime(2017, 09, 29),
						EstimateInHour = random.Next(5, 40),
						EmployeeId = 4,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Finalize Testing Plan",
						Status = Status.InProgress,
						Type = TaskType.Development,
						Description = "Description to Finalize Testing Plan",
						Deadline = new DateTime(2017, 10, 12),
						EstimateInHour = random.Next(5, 15),
						EmployeeId = 2,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Submit Expensive Report",
						Status = Status.Closed,
						Type = TaskType.Development,
						Description = "Description to Submit Expensive Report",
						Deadline = new DateTime(2017, 08, 11),
						EstimateInHour = random.Next(5, 40),
						EmployeeId = 2,
						ProjectId = 1
					},
					new ProjectTask
					{
						Title = "Optimize Drill-Down Filter",
						Status = Status.InProgress,
						Type = TaskType.Development,
						Description = "Descripation About Finalize Testing Plan",
						Deadline = new DateTime(2017, 08, 15),
						EstimateInHour = random.Next(5, 15),
						EmployeeId = 1,
						ProjectId = 1
					},
				});

				context.SaveChanges();
			}

			if (!context.ProjectLogs.Any())
			{
				context.ProjectLogs.AddRange(new List<ProjectLog>()
				{
					new ProjectLog
					{
						Type = LogType.TaskFinised,
						CreationDate = new DateTime(2017, 08, 11),
						EmployeeId = 2,
						ProjectTaskId = 21
					},
					new ProjectLog
					{
						Type = LogType.NewComment,
						CreationDate = new DateTime(2017, 08, 15),
						EmployeeId = 1,
						ProjectTaskId = 22
					},
					new ProjectLog
					{
						Type = LogType.TaskOverdue,
						CreationDate = new DateTime(2017, 08, 15),
						EmployeeId = 2,
						ProjectTaskId = 13
					}
				});

				context.SaveChanges();
			}
		}
	}
}

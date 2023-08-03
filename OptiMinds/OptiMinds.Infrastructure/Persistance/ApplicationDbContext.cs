using Microsoft.EntityFrameworkCore;
using OptiMinds.Domain.Entities;
using OptiMinds.Infrastructure.Persistance.Configuration;

namespace OptiMinds.Infrastructure.Persistance
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProjectConfiguration());
			modelBuilder.Entity<EmployeeProject>().Ignore(e => e.Id);

			base.OnModelCreating(modelBuilder);

		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<ProjectTask> Tasks { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectLog> ProjectLogs { get; set; }
		public DbSet<EmployeeProject> EmployeeProjects { get; set; }
	}
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OptiMinds.Domain.Entities;

namespace OptiMinds.Infrastructure.Persistance.Configuration
{
	public class ProjectConfiguration : IEntityTypeConfiguration<Project>
	{
		public void Configure(EntityTypeBuilder<Project> builder)
		{
			builder
				.HasMany(e => e.Employees)
				.WithMany(e => e.Projects)
				.UsingEntity<EmployeeProject>(
					j => j
						.HasOne<Employee>()
						.WithMany()
						.HasForeignKey(e => e.EmployeeId),
					j => j
						.HasOne<Project>()
						.WithMany()
						.HasForeignKey(e => e.ProjectId)
				);
		}
	}
}

using OptiMinds.Domain.Common.Models;
using OptiMinds.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptiMinds.Domain.Entities
{
    public class ProjectTask : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public Status Status { get; set; }

        [Required]
        public TaskType Type { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public float EstimateInHour { get; set; }

        [ForeignKey(nameof(Employee))]
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}

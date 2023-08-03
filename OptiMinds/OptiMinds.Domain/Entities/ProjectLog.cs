using OptiMinds.Domain.Common.Models;
using OptiMinds.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptiMinds.Domain.Entities
{
    public class ProjectLog : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public LogType Type { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

		[ForeignKey(nameof(ProjectTask))]
		public int ProjectTaskId { get; set; }
        public virtual ProjectTask ProjectTask { get; set; }
    }
}
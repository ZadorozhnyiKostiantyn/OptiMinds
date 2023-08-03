using OptiMinds.Domain.Common.Models;
using OptiMinds.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OptiMinds.Domain.Entities
{
    public class Project : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public Status OverallStatus { get; set; }

        [Required]
        public float TotalBudget { get; set; }

        [Required]
        public float SpendBudget { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

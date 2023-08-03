using OptiMinds.Domain.Common.Models;
using OptiMinds.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OptiMinds.Domain.Entities
{
    public class Employee : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        public EmployeeType EmployeeType { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}

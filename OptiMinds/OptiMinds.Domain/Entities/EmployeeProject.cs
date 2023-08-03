using OptiMinds.Domain.Common.Models;
using System.Runtime.Serialization;

namespace OptiMinds.Domain.Entities
{
	public class EmployeeProject : IEntity
	{
		public int EmployeeId { get; set; }
		public int ProjectId { get; set; }

		[IgnoreDataMember]
		public int Id { get; set; }
	}
}

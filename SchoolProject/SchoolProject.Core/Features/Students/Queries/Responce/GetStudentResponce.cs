using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Results
{
	public class GetStudentResponce
	{
		[Key]
		public int StudID { get; set; }
		[StringLength(200)]
		public string? Name { get; set; }
		[StringLength(500)]
		public string? Address { get; set; }
		[StringLength(500)]
		public string? Phone { get; set; }
		public string? DepartmentName { get; set; }
	}
}

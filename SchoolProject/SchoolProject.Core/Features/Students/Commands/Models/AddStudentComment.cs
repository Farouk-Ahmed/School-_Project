using MediatR;
using SchoolProject.Core.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
	public class AddStudentComment:IRequest<Response<string>>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		[StringLength(500)]
		public string Address { get; set; }
		[StringLength(500)]
		public string Phone { get; set; }
		public int DepartmentId { get; set; }
	}
}

﻿using MediatR;
using SchoolProject.Core.Basic;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
	public class AddStudentComment : IRequest<Response<string>>
	{
		public string Name { get; set; }

		public string Address { get; set; }

		public string Phone { get; set; }
		public int DepartmentId { get; set; }
	}
}

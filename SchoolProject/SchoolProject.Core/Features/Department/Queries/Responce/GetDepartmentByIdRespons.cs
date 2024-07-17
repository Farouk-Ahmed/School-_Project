﻿using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Department.Queries.Responce
{
	public class GetDepartmentByIdRespons
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? ManagerName { get; set; }
		public PaginationResult<StudentResponse>? StudentList { get; set; }
		public List<SubjectResponse>? SubjectList { get; set; }
		public List<InstructorResponse>? InstructorList { get; set; }

	}
	public class StudentResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public StudentResponse(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
	public class SubjectResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public class InstructorResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

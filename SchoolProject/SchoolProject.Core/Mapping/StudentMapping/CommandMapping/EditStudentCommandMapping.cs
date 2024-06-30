﻿using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entityes;

namespace SchoolProject.Core.Mapping.StudentMapping
{
	public partial class StudentProfile
	{
		public void EditStudentCommandMapping()
		{
			CreateMap<EditStudentCommand, Student>()
				.ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId))
				.ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.Id));
		}

	}
}
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.StudentMapping
{
	public partial class StudentProfile
	{
		public void AddStudentCommandMapping()
		{
			CreateMap<AddStudentComment,Student >()
				.ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId));
		}
	}
}

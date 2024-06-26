using SchoolProject.Core.Features.Students.Queries.Responce;
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
		public void GetStudentByIDMapping()
		{
			CreateMap<Student, GetSingelStudentResponse>()
				.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
		}
	}
}

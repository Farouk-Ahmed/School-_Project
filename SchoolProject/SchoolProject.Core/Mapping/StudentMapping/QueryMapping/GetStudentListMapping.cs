using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entityes;

namespace SchoolProject.Core.Mapping.StudentMapping
{
	public partial class StudentProfile
	{
		public void GetStudentListMapping()
		{
			CreateMap<Student, GetStudentResponce>()
				.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DNameAr));
		}
	}
}

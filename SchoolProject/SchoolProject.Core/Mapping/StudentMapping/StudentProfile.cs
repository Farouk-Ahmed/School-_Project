using AutoMapper;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entityes;

namespace SchoolProject.Core.Mapping.StudentMapping
{
	public partial class StudentProfile : Profile
	{
		public StudentProfile()
		{
			CreateMap<Student, GetStudentResponce>()
			.ForMember(response => response.DepartmentName, options => options.MapFrom(Sour => Sour.Department.DNameEn))
			.ForMember(response => response.Name, options => options.MapFrom(Sour => Sour.GetLocalizer(Sour.NameAr, Sour.NameEn)));

			//GetStudentListMapping();
			GetStudentByIDMapping();
			AddStudentCommandMapping();
			EditStudentCommandMapping();

		}
	}
}

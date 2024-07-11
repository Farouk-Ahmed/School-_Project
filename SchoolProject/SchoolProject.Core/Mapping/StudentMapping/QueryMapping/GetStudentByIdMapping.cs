using SchoolProject.Core.Features.Students.Queries.Responce;
using SchoolProject.Data.Entityes;

namespace SchoolProject.Core.Mapping.StudentMapping

{
	public partial class StudentProfile
	{
		public void GetStudentByIDMapping()
		{
			CreateMap<Student, GetSingelStudentResponse>()
				.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.GetLocalizer(src.Department.DNameAr, src.Department.DNameEn)))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalizer(src.NameAr, src.NameEn)));
		}
	}
}

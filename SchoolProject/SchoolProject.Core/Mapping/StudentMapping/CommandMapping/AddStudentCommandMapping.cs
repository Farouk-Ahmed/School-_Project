using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entityes;

namespace SchoolProject.Core.Mapping.StudentMapping
{
	public partial class StudentProfile
	{
		public void AddStudentCommandMapping()
		{
			CreateMap<AddStudentComment, Student>()
				.ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId))
				.ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
				.ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr));
		}
	}
}

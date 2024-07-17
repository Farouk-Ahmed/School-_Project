using SchoolProject.Core.Features.Department.Queries.Responce;
using SchoolProject.Data.Entityes;

namespace SchoolProject.Core.Mapping.DepartmentMapping
{
	public partial class DepartmentProfiel
	{
		public void GetDepartmentByIdMapping()
		{

			CreateMap<Department, GetDepartmentByIdRespons>()
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalizer(src.DNameAr, src.DNameEn)))
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
			.ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.GetLocalizer(src.Instructor.ENameAr, src.Instructor.ENameEn)))
			.ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
			//.ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
			.ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors));




			CreateMap<DepartmetSubject, SubjectResponse>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.GetLocalizer(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));


			//CreateMap<Student, StudentResponse>()
			//		.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
			//		.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalizer(src.NameAr, src.NameEn)));

			CreateMap<Instructor, InstructorResponse>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalizer(src.ENameAr, src.ENameEn)));

		}
	}
}

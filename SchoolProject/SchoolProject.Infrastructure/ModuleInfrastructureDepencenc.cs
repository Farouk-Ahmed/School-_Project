using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.InfrastructureBasic;
using SchoolProject.Infrastructure.Reposatiry;

namespace SchoolProject.Infrastructure
{
	public static class ModuleInfrastructureDepencenc
	{
		public static IServiceCollection addInfrastructureDepencenc(this IServiceCollection services)
		{
			services.AddTransient<IStudentRepository, StudentRepository>();
			services.AddTransient<IDepartmentRepository, DepartmentRepository>();
			services.AddTransient<InsstructorRepository, InsstructorRepository>();
			services.AddTransient<ISubjectRepository, SubjectRepository>();
			services.AddTransient(typeof(IGenericRepos<>), typeof(GenericRepos<>));
			return services;
		}

	}
}

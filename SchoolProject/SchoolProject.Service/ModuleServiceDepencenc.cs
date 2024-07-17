using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstrcte;
using SchoolProject.Service.Implemntations;

namespace SchoolProject.Service
{
	public static class ModuleServiceDepencenc
	{
		public static IServiceCollection addServiceDepencenc(this IServiceCollection services)
		{
			services.AddTransient<IStudentServes, StudentServes>();
			services.AddTransient<IDepartmentServes, DepartmentServes>();
			return services;
		}

	}
}

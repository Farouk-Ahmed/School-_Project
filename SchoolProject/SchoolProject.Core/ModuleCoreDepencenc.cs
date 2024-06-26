using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SchoolProject.Core
{
	public static class ModuleCoreDepencenc
	{

		//Configuration Of Madiatr
		public static IServiceCollection addCoreDepencenc(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			//Configuration Of Automapper
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			return services;
		}

	}
}

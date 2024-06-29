﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviors;
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
			// Get Validators
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
			return services;
		}

	}
}

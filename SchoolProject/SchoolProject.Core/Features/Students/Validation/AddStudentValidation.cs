
using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstrcte;

namespace SchoolProject.Core.Features.Students.Validation
{
	public class AddStudentValidation : AbstractValidator<AddStudentComment>
	{
		#region Fildes
		private readonly IStringLocalizer<SharedResourcesed> _localizer;
		private readonly IStudentServes _studentServes;
		private readonly IDepartmentServes _departmentServes;
		#endregion

		#region Ctor
		public AddStudentValidation(IStudentServes studentServes, IStringLocalizer<SharedResourcesed> Localizer, IDepartmentServes departmentServes)
		{

			_localizer = Localizer;
			_studentServes = studentServes;
			_departmentServes = departmentServes;
			ApplyValidationsRules();
			ApplyCustomeValidationsRules();
		}
		#endregion
		#region Actions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.NameEn).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.NameAr).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.Address).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.DepartmentId).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
			#endregion
		}

		public void ApplyCustomeValidationsRules()
		{
			RuleFor(x => x.NameEn)
				.MustAsync(async (key, CancellationToken) => !await _studentServes.IsNameExist(key))
				.WithMessage(_localizer[SharedResourcesKeys.IsExist]);
			RuleFor(x => x.NameAr)
				.MustAsync(async (key, CancellationToken) => !await _studentServes.IsNameExist(key))
				.WithMessage(_localizer[SharedResourcesKeys.IsExist]);


			RuleFor(x => x.DepartmentId)
				.MustAsync(async (key, CancellationToken) => await _departmentServes.IsDepartmentExist(key))
				.WithMessage(_localizer[SharedResourcesKeys.DepartmementIdisNotExist]);
		}
	}
}

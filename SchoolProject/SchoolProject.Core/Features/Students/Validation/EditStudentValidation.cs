using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstrcte;

namespace SchoolProject.Core.Features.Students.Validation
{
	public class EditStudentValidation : AbstractValidator<EditStudentCommand>
	{
		#region Fildes
		private readonly IStudentServes _studentServes;
		private readonly IStringLocalizer<SharedResourcesed> _localizer;
		#endregion

		#region Ctor
		public EditStudentValidation(IStudentServes studentServes, IStringLocalizer<SharedResourcesed> Localizer)
		{
			_studentServes = studentServes;
			_localizer = Localizer;
			ApplyValidationsRules();
			ApplyCustomeValidationsRules();
		}
		#endregion
		#region Actions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.NameEn).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.MaximumLength(20).WithMessage("The Name must not be more than 20 characters");

			RuleFor(x => x.Address).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(100).WithMessage("The Address must not be more than 100 characters");

			#endregion
		}

		public void ApplyCustomeValidationsRules()
		{
			RuleFor(x => x.NameEn)
				.MustAsync(async (model, key, CancellationToken) => !await _studentServes.IsNameExistExcludeSelf(key, model.Id))
				.WithMessage("Name Is Exist");

		}
	}
}

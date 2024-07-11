
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
		private readonly IStudentServes _studentServes;
		private readonly IStringLocalizer<SharedResourcesed> _localizer;
		#endregion

		#region Ctor
		public AddStudentValidation(IStudentServes studentServes, IStringLocalizer<SharedResourcesed> Localizer)
		{

			this._studentServes = studentServes;
			this._localizer = Localizer;
			ApplyValidationsRules();
			ApplyCustomeValidationsRules();
		}
		#endregion
		#region Actions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.NameEn).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.MaximumLength(20).WithMessage("The Address must not be more than 20 characters");

			RuleFor(x => x.Address).NotEmpty().WithMessage("Address Must Not Be Empty")
									.NotNull().WithMessage("Address Must Not Be Null")
									.MaximumLength(100).WithMessage("The Address must not be more than 100 characters");

			#endregion
		}

		public void ApplyCustomeValidationsRules()
		{
			RuleFor(x => x.NameEn)
				.MustAsync(async (key, CancellationToken) => !await _studentServes.IsNameExist(key))
				.WithMessage("Name Is Exist");

		}
	}
}

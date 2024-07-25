using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.AppUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.AppUser.Commands.Validator
{
	public class AddUserValidator : AbstractValidator<AddUserCommand>
	{
		#region Fildes
		private readonly IStringLocalizer<SharedResourcesed> _localizer;
		#endregion

		#region Ctor
		public AddUserValidator(IStringLocalizer<SharedResourcesed> localizer)
		{
			_localizer = localizer;
			ApplyValidationsRules();
			ApplyCustomeValidationsRules();
		}
		#endregion

		#region Hundle Func
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.FullName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
							.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
			.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.UserName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.Email).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.Password).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.ConfirmPassword)
				.Equal(x => x.Password)
				.NotEmpty().WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);


			#endregion
		}
		public void ApplyCustomeValidationsRules()
		{

		}

	}
}

using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.AppUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.AppUser.Commands.Validator
{
	public class UpDateUserValidator : AbstractValidator<UpDateUserCommand>
	{
		#region Fildes
		private readonly IStringLocalizer<SharedResourcesed> _localizer;
		#endregion

		#region Ctor
		public UpDateUserValidator(IStringLocalizer<SharedResourcesed> localizer)
		{
			_localizer = localizer;
			ApplyValidationsRules();
			ApplyCustomeValidationsRules();
		}
		#endregion

		#region Hundle Func
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.FullName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NoImage])
							.NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
			.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.UserName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.Email).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.Address).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);
			RuleFor(x => x.Country).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
								.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);



			#endregion
		}
		public void ApplyCustomeValidationsRules()
		{

		}

	}

}


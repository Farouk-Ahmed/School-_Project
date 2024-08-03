using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authentication.Commands.Validation
{
	public class signinValedator : AbstractValidator<signinCommand>
	{
		#region Fildes
		private IStringLocalizer<SharedResourcesed> _localizer;
		#endregion
		#region Ctor

		public signinValedator(IStringLocalizer<SharedResourcesed> Localizer)
		{

			_localizer = Localizer;

			ApplyValidationsRules();
			ApplyCustomeValidationsRules();
		}
		#endregion
		#region Actions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.UserName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
								.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.PassWord).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
								.NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
								.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			#endregion
		}

		public void ApplyCustomeValidationsRules()
		{

		}
	}
}

using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.AppUser.Commands.Models;
using SchoolProject.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.AppUser.Commands.Validator
{
	public class ChangeUserPasswordValidator:AbstractValidator<ChangeUserPasswordCommand>
	{
		#region Fildes
		private readonly IStringLocalizer<SharedResourcesed> _localizer;
		#endregion

		#region Ctor
		public ChangeUserPasswordValidator(IStringLocalizer<SharedResourcesed> localizer)
		{
			_localizer = localizer;
			ApplyValidationsRules();
			ApplyCustomeValidationsRules();
		}
		#endregion

		#region Hundle Func
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
							.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);

			RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.NewPassword).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
									.MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis20]);

			

			#endregion
		}
		public void ApplyCustomeValidationsRules()
		{

		}
	}
}

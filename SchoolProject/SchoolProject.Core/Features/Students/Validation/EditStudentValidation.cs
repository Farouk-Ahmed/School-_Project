using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstrcte;

namespace SchoolProject.Core.Features.Students.Validation
{
	public class EditStudentValidation : AbstractValidator<EditStudentCommand>
	{
		#region Fildes
		private readonly IStudentServes _studentServes;
		#endregion

		#region Ctor
		public EditStudentValidation(IStudentServes studentServes)
		{
			ApplyValidationsRules();
			ApplyCustomeValidationsRules();
			this._studentServes = studentServes;
		}
		#endregion
		#region Actions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name Must Not Be Empty")
								.NotNull().WithMessage("Name Must Not Be Null")
								.MaximumLength(20).WithMessage("The Name must not be more than 20 characters");

			RuleFor(x => x.Address).NotEmpty().WithMessage("Address Must Not Be Empty")
									.NotNull().WithMessage("Address Must Not Be Null")
									.MaximumLength(100).WithMessage("The Address must not be more than 100 characters");

			#endregion
		}

		public void ApplyCustomeValidationsRules()
		{
			RuleFor(x => x.Name)
				.MustAsync(async (model, key, CancellationToken) => !await _studentServes.IsNameExistExcludeSelf(key, model.Id))
				.WithMessage("Name Is Exist");

		}
	}
}

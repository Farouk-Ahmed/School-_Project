using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entityes.Identity;
using SchoolProject.Service.Abstrcte;

namespace SchoolProject.Core.Features.Authentication.Commands.Handles
{
	public class AuthenticationCommandHandler : ResponseHandler,

		IRequestHandler<signinCommand, Response<string>>
	{
		#region Fields
		private readonly IStringLocalizer<SharedResourcesed> _localizer;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signIn;
		private readonly IAuthenticationServes _authentication;
		#endregion
		#region Ctor
		public AuthenticationCommandHandler(IStringLocalizer<SharedResourcesed> Localizer,
										   UserManager<User> userManager,
										  SignInManager<User> signIn,
										  IAuthenticationServes authentication) : base(Localizer)
		{
			_localizer = Localizer;
			_userManager = userManager;
			_signIn = signIn;
			_authentication = authentication;
		}

		#endregion
		#region Handel Func
		public async Task<Response<string>> Handle(signinCommand request, CancellationToken cancellationToken)
		{
			//check if user is exist
			var user = await _userManager.FindByNameAsync(request.UserName);
			//Return Usr name not found
			if (user == null) return BadRequest<string>(_localizer[SharedResourcesKeys.UserNameIsNotExist]);
			//Try to sign in
			var sigIn = _signIn.CheckPasswordSignInAsync(user, request.PassWord, false);
			//if faild return password is wrong
			if (!sigIn.IsCompletedSuccessfully) return BadRequest<string>(_localizer[SharedResourcesKeys.PasswordNotCorrect]);
			//Generate token
			var token = await _authentication.Get_JWTToken(user);
			//Rutern token
			return Success(token);
		}
		#endregion
	}
}

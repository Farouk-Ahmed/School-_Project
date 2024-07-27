using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.AppUser.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entityes.Identity;

namespace SchoolProject.Core.Features.AppUser.Commands.Handles
{
	public class UserCommandHandler : ResponseHandler,
		IRequestHandler<AddUserCommand, Response<string>>,
		IRequestHandler<UpDateUserCommand, Response<string>>,
		IRequestHandler<DeleteUserCommand, Response<string>>
	{
		#region Fildes
		private readonly IStringLocalizer<SharedResourcesed> _localizer;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;
		#endregion
		#region Ctor
		public UserCommandHandler(IStringLocalizer<SharedResourcesed> Localizer,
								  IMapper mapper,
								UserManager<User> userManager) : base(Localizer)
		{
			_localizer = Localizer;
			_mapper = mapper;
			_userManager = userManager;
		}



		#endregion
		#region Handels Func

		public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			//If Email Exist
			var user = await _userManager.FindByEmailAsync(request.Email);
			//Email is Exist
			if (user != null) return BadRequest<string>(_localizer[SharedResourcesKeys.EmailIsExist]);

			//If UserName Exist
			var Byusername = _userManager.FindByNameAsync(request.UserName);
			//UserName is Exist
			if (Byusername == null) return BadRequest<string>(_localizer[SharedResourcesKeys.UserNameIsExist]);

			//Mapping
			var identityUser = _mapper.Map<User>(request);
			//Create
			var Result = await _userManager.CreateAsync(identityUser, request.Password);
			//Failed
			if (!Result.Succeeded)
			{
				return BadRequest<string>(Result.Errors.FirstOrDefault().Description);
			}
			//message
			//Sucess
			return Created("");

		}

		public async Task<Response<string>> Handle(UpDateUserCommand request, CancellationToken cancellationToken)
		{
			//check if user exist
			var olduser = await _userManager.FindByIdAsync(request.Id.ToString());
			//not found
			if (olduser == null) return NotFound<string>();
			//mapping
			var newuser = _mapper.Map(request, olduser);
			//update
			var resul = await _userManager.UpdateAsync(newuser);
			//result is not success
			if (!resul.Succeeded)
			{
				return BadRequest<string>(_localizer[SharedResourcesKeys.UpdateFailed]);
			}
			//message
			return Success((string)_localizer[SharedResourcesKeys.Updated]);
		}

		public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			//check if user exist
			var user = await _userManager.FindByIdAsync(request.Id.ToString());
			//not found
			if (user == null) return NotFound<string>();
			//Deleted
			var Ruslt = await _userManager.DeleteAsync(user);
			// in case of failed
			if (!Ruslt.Succeeded)
			{
				return BadRequest<string>(_localizer[SharedResourcesKeys.DeletedFailed]);
			}
			//message
			return Delete((string)_localizer[SharedResourcesKeys.DeletedFailed]);



		}

		#endregion
	}
}

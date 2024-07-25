using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.AppUser.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	public class AppUserController : AppControllerBase
	{
		[HttpPost(Router.AppUserRouting.Create)]
		public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
		{

			return NewResult(await _mediator.Send(command));
		}
	}
}

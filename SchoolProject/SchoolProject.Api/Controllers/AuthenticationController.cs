using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{

	[ApiController]
	public class AuthenticationController : AppControllerBase
	{
		[HttpPost(RouteApp.Authentication.signin)]
		public async Task<IActionResult> AddUser([FromForm] signinCommand command)
		{

			var response = await _mediator.Send(command);
			return NewResult(response);
		}
	}
}

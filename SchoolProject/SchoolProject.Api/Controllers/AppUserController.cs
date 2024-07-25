using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.AppUser.Commands.Models;
using SchoolProject.Core.Features.AppUser.Queries.Models;
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

		[HttpGet(Router.AppUserRouting.Paginated)]
		public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery query)
		{

			var response = await _mediator.Send(query);
			return Ok(response);
		}

		[HttpGet(Router.AppUserRouting.GetById)]
		public async Task<IActionResult> GetStudentByID([FromRoute] int id)
		{

			return NewResult(await _mediator.Send(new GetSingelUserQuery(id)));
		}
	}
}

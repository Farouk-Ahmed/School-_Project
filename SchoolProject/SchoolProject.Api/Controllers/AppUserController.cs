using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.AppUser.Commands.Models;
using SchoolProject.Core.Features.AppUser.Queries.Models;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	public class AppUserController : AppControllerBase
	{
		[HttpPost(Data.AppMetaData.RouteApp.AppUserRouting.Create)]
		public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
		{

			return NewResult(await _mediator.Send(command));
		}

		[HttpGet(Data.AppMetaData.RouteApp.AppUserRouting.Paginated)]
		public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery query)
		{

			var response = await _mediator.Send(query);
			return Ok(response);
		}

		[HttpGet(Data.AppMetaData.RouteApp.AppUserRouting.GetById)]
		public async Task<IActionResult> GetuserByID([FromRoute] int id)
		{

			return NewResult(await _mediator.Send(new GetSingelUserQuery(id)));
		}
		[HttpPut(Data.AppMetaData.RouteApp.AppUserRouting.Edit)]

		public async Task<IActionResult> Edit([FromBody] UpDateUserCommand comment)
		{

			return NewResult(await _mediator.Send(comment));
		}
		[HttpDelete(Data.AppMetaData.RouteApp.AppUserRouting.Delete)]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{

			return NewResult(await _mediator.Send(new DeleteUserCommand(id)));
		}
		[HttpPut(Data.AppMetaData.RouteApp.AppUserRouting.changpassword)]

		public async Task<IActionResult> changpassword([FromBody] ChangeUserPasswordCommand comment)
		{

			return NewResult(await _mediator.Send(comment));
		}
	}
}

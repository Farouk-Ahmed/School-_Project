using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;

namespace SchoolProject.Api.Controllers
{
	//[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class StudentsController : AppControllerBase
	{


		[HttpGet(Data.AppMetaData.RouteApp.StudentRouting.List)]
		public async Task<IActionResult> GetStudent()
		{
			var response = await _mediator.Send(new GetStudentQuary());
			return Ok(response);
		}
		[AllowAnonymous]
		[HttpGet(Data.AppMetaData.RouteApp.StudentRouting.Paginated)]
		public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
		{
			var response = await _mediator.Send(query);
			return Ok(response);
		}
		[HttpGet(Data.AppMetaData.RouteApp.StudentRouting.GetById)]
		public async Task<IActionResult> GetStudentByID([FromRoute] int id)
		{

			return NewResult(await _mediator.Send(new GetStudentByIdQuarey(id)));
		}
		[HttpPost(Data.AppMetaData.RouteApp.StudentRouting.Create)]
		public async Task<IActionResult> GetStudentByID([FromBody] AddStudentComment comment)
		{

			return NewResult(await _mediator.Send(comment));
		}
		[HttpPut(Data.AppMetaData.RouteApp.StudentRouting.Edit)]
		public async Task<IActionResult> Edit([FromBody] EditStudentCommand comment)
		{

			return NewResult(await _mediator.Send(comment));
		}
		[HttpDelete(Data.AppMetaData.RouteApp.StudentRouting.Delete)]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{

			return NewResult(await _mediator.Send(new DeleteStudeentCommand(id)));
		}
	}
}

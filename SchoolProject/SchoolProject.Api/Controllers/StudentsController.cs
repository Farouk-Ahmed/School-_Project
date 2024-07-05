using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	//[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : AppControllerBase
	{

		[HttpGet(Router.StudentRouting.List)]
		public async Task<IActionResult> GetStudent()
		{
			var response = await _mediator.Send(new GetStudentQuary());
			return Ok(response);
		}
		[HttpGet(Router.StudentRouting.Paginated)]
		public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
		{
			var response = await _mediator.Send(query);
			return Ok(response);
		}
		[HttpGet(Router.StudentRouting.GetById)]
		public async Task<IActionResult> GetStudentByID([FromRoute] int id)
		{

			return NewResult(await _mediator.Send(new GetStudentByIdQuarey(id)));
		}
		[HttpPost(Router.StudentRouting.Create)]
		public async Task<IActionResult> GetStudentByID([FromBody] AddStudentComment comment)
		{

			return NewResult(await _mediator.Send(comment));
		}
		[HttpPut(Router.StudentRouting.Edit)]
		public async Task<IActionResult> Edit([FromForm] EditStudentCommand comment)
		{

			return NewResult(await _mediator.Send(comment));
		}
		[HttpDelete(Router.StudentRouting.Delete)]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{

			return NewResult(await _mediator.Send(new DeleteStudeentCommand(id)));
		}
	}
}

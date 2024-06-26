using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	//[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public StudentsController(IMediator mediator)
        {
			this._mediator = mediator;
		}
		[HttpGet(Router.StudentRouting.List)]
		public async Task<IActionResult> GetStudent() 
		{
			var response = await _mediator.Send(new GetStudentQuary());
			return Ok(response);
		}
		[HttpGet(Router.StudentRouting.GetById)]
		public async Task<IActionResult> GetStudentByID([FromRoute]int id)
		{
			var response = await _mediator.Send(new GetStudentByIdQuarey (id));
			return Ok(response);
		}
		[HttpPost(Router.StudentRouting.Create)]
		public async Task<IActionResult> GetStudentByID([FromBody] AddStudentComment comment)
		{
			var response = await _mediator.Send(comment);
			return Ok(response);
		}
	}
}

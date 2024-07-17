using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Department.Queries.Models;
using Router = SchoolProject.Data.AppMetaData.Router;

namespace SchoolProject.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : AppControllerBase
	{
		[HttpGet(Router.DepartmentRouting.GetById)]
		public async Task<IActionResult> GetDepartmentByID([FromQuery] GetDepartmebtByIdQueries byIdQueries)
		{

			return NewResult(await _mediator.Send(byIdQueries));
		}
	}
}

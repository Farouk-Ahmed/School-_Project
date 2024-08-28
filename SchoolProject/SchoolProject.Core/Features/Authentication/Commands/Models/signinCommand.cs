using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
	public class signinCommand : IRequest<Response<JWTAuthResult>>
	{
		public string UserName { get; set; }
		public string PassWord { get; set; }
	}
}

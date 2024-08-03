using MediatR;
using SchoolProject.Core.Basic;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
	public class signinCommand : IRequest<Response<string>>
	{
		public string UserName { get; set; }
		public string PassWord { get; set; }
	}
}

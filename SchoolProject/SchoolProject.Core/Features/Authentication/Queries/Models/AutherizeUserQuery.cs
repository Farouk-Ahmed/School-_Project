using MediatR;
using SchoolProject.Core.Basic;

namespace SchoolProject.Core.Features.Authentication.Queries.Models
{
	public class AutherizeUserQuery : IRequest<Response<string>>
	{
		public string AccessToken { get; set; }
	}
}

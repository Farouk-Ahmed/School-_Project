using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
	public class RefreshTokenCommand : IRequest<Response<JWTAuthResult>>
	{
		public string AccessToken { get; set; }
		public string  RefreshToken { get; set; }
 
	}
}

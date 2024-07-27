using MediatR;
using SchoolProject.Core.Basic;

namespace SchoolProject.Core.Features.AppUser.Commands.Models
{
	public class UpDateUserCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string? Address { get; set; }
		public string? Country { get; set; }
		public string PhoneNumber { get; set; }
	}
}

using MediatR;
using SchoolProject.Core.Basic;

namespace SchoolProject.Core.Features.AppUser.Commands.Models
{
	public class DeleteUserCommand : IRequest<Response<string>>

	{
		public int Id { get; set; }
		public DeleteUserCommand(int id)
		{
			Id = id;
		}
	}
}

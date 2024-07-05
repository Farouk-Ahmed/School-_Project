using MediatR;
using SchoolProject.Core.Basic;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
	public class DeleteStudeentCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }

		public DeleteStudeentCommand(int id)
		{
			Id = id;
		}

	}
}

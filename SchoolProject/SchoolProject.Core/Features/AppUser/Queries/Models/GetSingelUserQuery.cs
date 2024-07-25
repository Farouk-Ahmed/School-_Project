using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.AppUser.Queries.Responce;

namespace SchoolProject.Core.Features.AppUser.Queries.Models
{
	public class GetSingelUserQuery : IRequest<Response<GetUserByIdResponse>>
	{
		public int Id { get; set; }
		public GetSingelUserQuery(int ID)
		{
			Id = ID;

		}
	}
}

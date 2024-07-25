using MediatR;
using SchoolProject.Core.Features.AppUser.Queries.Responce;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.AppUser.Queries.Models
{
	public class GetUserPaginationQuery : IRequest<PaginationResult<GetUserpaginationResponce>>
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}

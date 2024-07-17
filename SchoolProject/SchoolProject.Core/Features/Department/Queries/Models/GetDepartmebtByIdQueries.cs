using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Department.Queries.Responce;

namespace SchoolProject.Core.Features.Department.Queries.Models
{
	public class GetDepartmebtByIdQueries : IRequest<Response<GetDepartmentByIdRespons>>
	{
		public int id { get; set; }
		public int StudentPageNumber { get; set; }
		public int StudentPageSize { get; set; }


	}

}

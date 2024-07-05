using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Queries.Responce;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
	public class GetStudentByIdQuarey : IRequest<Response<GetSingelStudentResponse>>
	{
		public int Id { get; set; }
		public GetStudentByIdQuarey(int id)
		{
			Id = id;
		}
	}
}

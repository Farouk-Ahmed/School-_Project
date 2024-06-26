using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Queries.Responce;
using SchoolProject.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
	public class GetStudentByIdQuarey:IRequest<Response<GetSingelStudentResponse>>
	{
        public int Id { get; set; }
        public GetStudentByIdQuarey(int id)
        {
                Id= id;
        }
    }
}

using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentQuary : IRequest<Response< List<GetStudentResponce>>>
    {

    }


}

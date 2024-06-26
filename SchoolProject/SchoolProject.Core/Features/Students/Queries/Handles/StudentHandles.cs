using AutoMapper;
using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responce;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entityes;
using SchoolProject.Service.Abstrcte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Handles
{
	public class StudentHandles : ResponseHandler,
								IRequestHandler<GetStudentQuary, Response<List<GetStudentResponce>>>,
								IRequestHandler<GetStudentByIdQuarey,Response<GetSingelStudentResponse>>

	{
		#region Fields
		private readonly IStudentServes _studentServes;
		private readonly IMapper _mapper;
		#endregion
		#region Ctor
		public StudentHandles(IStudentServes studentServes, IMapper mapper)
        {
			this._studentServes = studentServes;
			this._mapper = mapper;
		}
        #endregion
        #region Handel Func
        public async Task< Response< List<GetStudentResponce>>> Handle(GetStudentQuary request, CancellationToken cancellationToken)
		{
			var StudentList= await _studentServes.GetStudentsAsync();
			var StudentListMapper = _mapper.Map<List<GetStudentResponce>>(StudentList);
			return Success( StudentListMapper);
		}

		public async Task<Response<GetSingelStudentResponse>> Handle(GetStudentByIdQuarey request, CancellationToken cancellationToken)
		{
			var GetStudentById = await _studentServes.GetStudentByIDsAsync(request.Id);
			if (GetStudentById == null) return NotFound<GetSingelStudentResponse>("The Object Is Not Found");
			var StudentByIDMapper =  _mapper.Map<GetSingelStudentResponse>(GetStudentById);
			return Success(StudentByIDMapper);
		}
        #endregion
	}
}

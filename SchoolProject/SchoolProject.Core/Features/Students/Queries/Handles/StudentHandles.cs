using AutoMapper;
using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responce;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entityes;
using SchoolProject.Service.Abstrcte;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handles
{
	public class StudentHandles : ResponseHandler,
								IRequestHandler<GetStudentQuary, Response<List<GetStudentResponce>>>,
								IRequestHandler<GetStudentByIdQuarey, Response<GetSingelStudentResponse>>,
								IRequestHandler<GetStudentPaginatedListQuery, PaginationResult<GetStudentPaginatedListResponse>>

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
		public async Task<Response<List<GetStudentResponce>>> Handle(GetStudentQuary request, CancellationToken cancellationToken)
		{
			var StudentList = await _studentServes.GetStudentsAsync();
			var StudentListMapper = _mapper.Map<List<GetStudentResponce>>(StudentList);
			return Success(StudentListMapper);
		}

		public async Task<Response<GetSingelStudentResponse>> Handle(GetStudentByIdQuarey request, CancellationToken cancellationToken)
		{
			var GetStudentById = await _studentServes.GetStudentByIDIncludesAsync(request.Id);
			if (GetStudentById == null) return NotFound<GetSingelStudentResponse>("The Object Is Not Found");
			var StudentByIDMapper = _mapper.Map<GetSingelStudentResponse>(GetStudentById);
			return Success(StudentByIDMapper);
		}

		public async Task<PaginationResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
		{
			Expression<Func<Student, GetStudentPaginatedListResponse>> exception = e => new GetStudentPaginatedListResponse(e.StudID, e.Name, e.Address, e.Phone, e.Department.DName);
			//var querabel = _studentServes.GetStudentsQueryable();
			var FilterQueryble = _studentServes.FilterStudentsQueryable(request.OrderBy, request.Search);
			var paginationList = await FilterQueryble.Select(exception).ToPaginationListAsync(request.PageNumber, request.PageSize);
			return paginationList;
		}
		#endregion
	}
}

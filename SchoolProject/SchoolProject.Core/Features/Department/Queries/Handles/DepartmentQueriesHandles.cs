using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Features.Department.Queries.Responce;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entityes;
using SchoolProject.Service.Abstrcte;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Department.Queries.Handles
{
	public class DepartmentQueriesHandles : ResponseHandler,
		IRequestHandler<GetDepartmebtByIdQueries, Response<GetDepartmentByIdRespons>>
	{
		#region Field
		private readonly IStringLocalizer<SharedResourcesed> _stringLocalizer;
		private readonly IMapper _mapper;
		private readonly IStudentServes _studentServes;
		private readonly IDepartmentServes _departmentServes;

		#endregion
		#region Ctor
		public DepartmentQueriesHandles(IStringLocalizer<SharedResourcesed> stringLocalizer,
									   IDepartmentServes departmentServes,
										IMapper mapper,
										IStudentServes studentServes) : base(stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			_mapper = mapper;
			_studentServes = studentServes;
			_departmentServes = departmentServes;
		}

		#endregion

		#region Handel Func
		public async Task<Response<GetDepartmentByIdRespons>> Handle(GetDepartmebtByIdQueries request, CancellationToken cancellationToken)
		{
			//Service Get By ID Incloud Student Subject Instrctour
			var response = await _departmentServes.GetDepartmentById(request.id);
			//Cheke Is Not Exist
			if (response == null) return NotFound<GetDepartmentByIdRespons>(_stringLocalizer[SharedResourcesKeys.NotFound]);
			//Mapping
			var Mapper = _mapper.Map<GetDepartmentByIdRespons>(response);
			//Pagination
			Expression<Func<Student, StudentResponse>> exception = e => new StudentResponse(e.StudID, e.GetLocalizer(e.NameAr, e.NameEn));
			var StudentQueryable = _studentServes.GetStudentsDepartmentByIdQueryable(request.id);
			var paginationList = await StudentQueryable.Select(exception).ToPaginationListAsync(request.StudentPageNumber, request.StudentPageSize);
			Mapper.StudentList = paginationList;
			//Return Response
			return Success(Mapper);
		}
		#endregion
	}
}

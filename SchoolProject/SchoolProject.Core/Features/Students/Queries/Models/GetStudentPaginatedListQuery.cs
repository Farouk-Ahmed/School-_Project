﻿
using MediatR;
using SchoolProject.Core.Features.Students.Queries.Responce;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
	public class GetStudentPaginatedListQuery : IRequest<PaginationResult<GetStudentPaginatedListResponse>>
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public string? Search { get; set; }
		public StudentOrderingEnum OrderBy { get; set; }
	}
}

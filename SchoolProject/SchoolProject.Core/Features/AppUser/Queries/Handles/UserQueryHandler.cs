using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.AppUser.Queries.Models;
using SchoolProject.Core.Features.AppUser.Queries.Responce;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entityes.Identity;

namespace SchoolProject.Core.Features.AppUser.Queries.Handles
{
	public class UserQueryHandler : ResponseHandler,
		IRequestHandler<GetUserPaginationQuery, PaginationResult<GetUserpaginationResponce>>,
		IRequestHandler<GetSingelUserQuery, Response<GetUserByIdResponse>>


	{
		#region Fields
		private readonly IStringLocalizer<SharedResourcesed> _localizer;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;
		#endregion
		#region Ctor
		public UserQueryHandler(IStringLocalizer<SharedResourcesed> localizer, IMapper mapper, UserManager<User> userManager) : base(localizer)
		{

			_localizer = localizer;
			_mapper = mapper;
			_userManager = userManager;
		}

		#endregion
		#region Handle Func
		public async Task<PaginationResult<GetUserpaginationResponce>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
		{
			var users = _userManager.Users.AsQueryable();
			var paginationList = await _mapper.ProjectTo<GetUserpaginationResponce>(users)
											  .ToPaginationListAsync(request.PageNumber, request.PageSize);
			return paginationList;
		}

		public async Task<Response<GetUserByIdResponse>> Handle(GetSingelUserQuery request, CancellationToken cancellationToken)
		{
			var userbyid = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
			//var user = _userManager.FindByIdAsync(request.Id.ToString());
			if (userbyid == null) return NotFound<GetUserByIdResponse>(_localizer[SharedResourcesKeys.NotFound]);
			var Ruslt = _mapper.Map<GetUserByIdResponse>(userbyid);
			return Success(Ruslt);


		}


		#endregion
	}
}

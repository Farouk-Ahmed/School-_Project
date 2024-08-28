using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstrcte;

namespace SchoolProject.Core.Features.Authentication.Queries.Handelr
{
	public class AuthentictionQueryHandler : ResponseHandler,

		IRequestHandler<AutherizeUserQuery, Response<string>>
	{
		#region Fields
		private readonly IStringLocalizer<SharedResourcesed> _localizer;
		private readonly IAuthenticationServes _authentication;
		#endregion
		#region Ctor
		public AuthentictionQueryHandler(IStringLocalizer<SharedResourcesed> Localizer,
										  IAuthenticationServes authentication) : base(Localizer)
		{
			_localizer = Localizer;
			_authentication = authentication;
		}
		#endregion

		#region Handel Func
		public async Task<Response<string>> Handle(AutherizeUserQuery request, CancellationToken cancellationToken)
		{
			var Rusrlt = await _authentication.ValidateToken(request.AccessToken);
			if (Rusrlt == "NotExpired")
				return Success(Rusrlt);
			return BadRequest<string>("Expired");


			#endregion
		}
	}
}
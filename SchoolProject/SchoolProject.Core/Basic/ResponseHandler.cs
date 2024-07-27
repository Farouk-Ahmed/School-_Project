using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Basic
{
	public class ResponseHandler
	{
		private readonly IStringLocalizer<SharedResourcesed> _Localizer;

		public ResponseHandler(IStringLocalizer<SharedResourcesed> Localizer)
		{
			_Localizer = Localizer;
		}
		public Response<T> Deleted<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = Message == null ? _Localizer[SharedResourcesKeys.Deleted] : Message
			};
		}
		public Response<T> Success<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = _Localizer[SharedResourcesKeys.Created],
				Meta = Meta
			};
		}
		public Response<T> Unauthorized<T>()
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.Unauthorized,
				Succeeded = true,
				Message = "UnAuthorized"
			};
		}
		public Response<T> BadRequest<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = false,
				Message = Message == null ? "Bad Request" : Message
			};
		}
		public Response<T> UnprocessableEntity<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
				Succeeded = false,
				Message = Message == null ? "Unprocessable Entity" : Message
			};
		}
		public Response<T> NotFound<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.NotFound,
				Succeeded = false,
				Message = message == null ? _Localizer[SharedResourcesKeys.NotFound] : message
			};
		}

		public Response<T> Created<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.Created,
				Succeeded = true,
				Message = _Localizer[SharedResourcesKeys.Created],
				Meta = Meta
			};
		}
		public Response<T> Delete<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.BadRequest,
				Succeeded = false,
				Message = _Localizer[SharedResourcesKeys.DeletedFailed],


			};
		}
	}
}

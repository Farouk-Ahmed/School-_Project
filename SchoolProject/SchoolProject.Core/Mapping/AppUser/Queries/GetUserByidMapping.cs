using SchoolProject.Core.Features.AppUser.Queries.Responce;
using SchoolProject.Data.Entityes.Identity;

namespace SchoolProject.Core.Mapping.AppUser
{
	public partial class CreateUserProfil
	{
		public void GetUserByidMapping()
		{
			CreateMap<User, GetUserByIdResponse>();

		}
	}
}

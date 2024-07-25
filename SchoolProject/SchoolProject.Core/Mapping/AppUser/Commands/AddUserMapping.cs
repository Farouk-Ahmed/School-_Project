using SchoolProject.Core.Features.AppUser.Commands.Models;
using SchoolProject.Data.Entityes.Identity;

namespace SchoolProject.Core.Mapping.AppUser
{
	public partial class CreateUserProfil
	{
		public void AddUserMapping()
		{
			CreateMap<AddUserCommand, User>();


		}

	}
}

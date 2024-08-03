using SchoolProject.Data.Entityes.Identity;

namespace SchoolProject.Service.Abstrcte
{
	public interface IAuthenticationServes
	{
		public Task<string> Get_JWTToken(User user);


	}
}

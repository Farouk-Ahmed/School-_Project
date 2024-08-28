using SchoolProject.Data.Entityes.Identity;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstrcte
{
	public interface IAuthenticationServes
	{
		public Task<JWTAuthResult> Get_JWTToken(User user);
		public Task<JWTAuthResult> Get_RefreshToken(String accessToken, string refreshToken);
		public Task<string> ValidateToken(string AccessToken);


	}
}

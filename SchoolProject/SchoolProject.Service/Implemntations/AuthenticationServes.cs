using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entityes.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Service.Abstrcte;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolProject.Service.Implemntations
{
	public class AuthenticationServes : IAuthenticationServes
	{
		#region Fields
		private readonly JwtSettings _jwtSettings;
		#endregion
		#region Ctor
		public AuthenticationServes(JwtSettings jwtSettings)
		{
			_jwtSettings = jwtSettings;
		}
		#endregion

		#region Handle Func

		public Task<string> Get_JWTToken(User user)
		{
			var Cliams = new List<Claim>()
			{
				new Claim(nameof(UserClaimModel.UserName),user.UserName),
				new Claim(nameof(UserClaimModel.Email),user.Email),
				new Claim(nameof(UserClaimModel.PhoneNumber),user.PhoneNumber),
			};
			var jwttoken = new JwtSecurityToken(
			  _jwtSettings.Issuer,
			  _jwtSettings.Audience,
			  Cliams,
			  expires: DateTime.Now.AddMinutes(2),
			  signingCredentials: new SigningCredentials(
				  new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
				  SecurityAlgorithms.HmacSha256Signature));
			var accessToken = new JwtSecurityTokenHandler().WriteToken(jwttoken);
			return Task.FromResult(accessToken);
		}
	}
	#endregion
}

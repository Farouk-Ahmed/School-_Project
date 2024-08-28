using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entityes.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstrcte;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Service.Implemntations
{
	public class AuthenticationServes : IAuthenticationServes
	{
		#region Fields
		private readonly JwtSettings _jwtSettings;
		private readonly IRefreshTokensRepository _refreshTokensRepository;
		private readonly UserManager<User> _userManager;
		#endregion
		#region Ctor
		public AuthenticationServes(JwtSettings jwtSettings,
									IRefreshTokensRepository refreshTokensRepository,
									UserManager<User> userManager)
		{
			_jwtSettings = jwtSettings;
			_refreshTokensRepository = refreshTokensRepository;
			_userManager = userManager;
		}
		#endregion

		#region Handle Func

		public async Task<JWTAuthResult> Get_JWTToken(User user)
		{
			var (jwttoken, accessToken) = GenarlJWTToken(user);
			var refreshToken = new RefreshToken
			{
				ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
				UserName = user.UserName,
				TokenString = GenerateRefreshToken()

			};
			var UserrefreshTokens = new UserRefreshToken
			{
				AddTime = DateTime.Now,
				ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
				IsUsed = true,
				IsRevoked = false,
				JWTId = jwttoken.Id,
				RefreshToken = refreshToken.TokenString,
				Token = accessToken,
				UserId = user.Id

			};
			await _refreshTokensRepository.AddAsync(UserrefreshTokens);
			var response = new JWTAuthResult();
			response.refreshToken = refreshToken;
			response.AccessToken = accessToken;

			return response;
		}
		private (JwtSecurityToken, string) GenarlJWTToken(User user)
		{
			var Cliams = GetClaims(user);
			var jwttoken = new JwtSecurityToken(
			  _jwtSettings.Issuer,
			  _jwtSettings.Audience,
			  Cliams,
			  expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
			  signingCredentials: new SigningCredentials(
				  new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
				  SecurityAlgorithms.HmacSha256Signature));
			var accessToken = new JwtSecurityTokenHandler().WriteToken(jwttoken);

			return (jwttoken, accessToken);
		}
		private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			var randomNumberGenerate = RandomNumberGenerator.Create();
			randomNumberGenerate.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}
		public List<Claim> GetClaims(User user)
		{
			var Cliams = new List<Claim>()
			{
				new Claim(nameof(UserClaimModel.UserName),user.UserName),
				new Claim(nameof(UserClaimModel.Email),user.Email),
				new Claim(nameof(UserClaimModel.PhoneNumber),user.PhoneNumber),
				new Claim(nameof(UserClaimModel.Id),user.Id.ToString()),
			};
			return Cliams;
		}
		public async Task<JWTAuthResult> Get_RefreshToken(string accessToken, string refreshToken)
		{
			//Read Toke to get cliams
			var jwtToken = ReadJWTToken(accessToken);
			if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
			{
				throw new SecurityTokenException("Algorithms Is Wrong");
			}
			if (jwtToken.ValidTo > DateTime.UtcNow)
			{
				throw new SecurityTokenException("Token Is Not Expired");

			}
			//var userid = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.Id)).Value;
			// Get User

			var userRefreshToken = await _refreshTokensRepository.GetTableNoTracking()
											.FirstOrDefaultAsync(x => x.Token == accessToken
														&& x.RefreshToken == refreshToken &&
														x.UserId == 1004);
			if (userRefreshToken == null)
			{
				throw new SecurityTokenException("RefreshToken Is Not Found");

			}
			// Validations Token
			if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
			{
				throw new SecurityTokenException("Token Is Expired");
			}
			var user = await _userManager.FindByIdAsync("1004");
			if (user == null)
			{
				userRefreshToken.IsRevoked = true;
				userRefreshToken.IsUsed = false;
				await _refreshTokensRepository.UpdateAsync(userRefreshToken);
				throw new SecurityTokenException("User Is Not Found");

			}
			var (jwtsectrtoken, newtoken) = GenarlJWTToken(user);
			var response = new JWTAuthResult();
			response.AccessToken = newtoken;
			var refreshtokenRuslt = new RefreshToken();
			refreshtokenRuslt.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.UserName)).Value;
			refreshtokenRuslt.TokenString = refreshToken;
			refreshtokenRuslt.ExpireAt = userRefreshToken.ExpiryDate;
			response.refreshToken = refreshtokenRuslt;

			return response;

		}
		private JwtSecurityToken ReadJWTToken(string accessToken)
		{
			if (string.IsNullOrEmpty(accessToken))
			{
				throw new ArgumentNullException(nameof(accessToken));
			}
			var handuler = new JwtSecurityTokenHandler();
			var response = handuler.ReadJwtToken(accessToken);

			return response;

		}

		public async Task<string> ValidateToken(string accessToken)
		{
			var handuler = new JwtSecurityTokenHandler();
			var prametrs = new TokenValidationParameters
			{
				ValidateIssuer = _jwtSettings.ValidateIssuer,
				ValidIssuers = new[] { _jwtSettings.Issuer },
				ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
				ValidAudience = _jwtSettings.Audience,
				ValidateAudience = _jwtSettings.ValidateAudience,
				ValidateLifetime = _jwtSettings.ValidateLifeTime,
			};
			var validator = handuler.ValidateToken(accessToken, prametrs, out SecurityToken validatedToken);
			try
			{
				if (validator == null)
				{
					throw new SecurityTokenException("Invalid Token");
				}
				return "NotExpired";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

	}
	#endregion
}

using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entityes.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBasic;

namespace SchoolProject.Infrastructure.Reposatiry
{
	public class RefreshTokensRepository : GenericRepos<UserRefreshToken>, IRefreshTokensRepository
	{
		#region Fields
		private DbSet<UserRefreshToken> refreshTokens;
		#endregion
		#region Ctor
		public RefreshTokensRepository(AppDBContext dbContext) : base(dbContext)
		{
			refreshTokens = dbContext.Set<UserRefreshToken>();
		}
		#endregion
		#region Handle Fun

		#endregion

	}
}

using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entityes;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBasic;

namespace SchoolProject.Infrastructure.Reposatiry
{
	public class InsstructorRepository : GenericRepos<Instructor>, IinsstructorRepository
	{

		#region Fields
		private DbSet<Instructor> instructor;
		#endregion
		#region Ctor
		public InsstructorRepository(AppDBContext dbContext) : base(dbContext)
		{
			instructor = dbContext.Set<Instructor>();
		}
		#endregion
		#region Handle Fun
		//public async Task<List<Department>> GetStudentsListAsync()
		//{
		//	return await departments.Include(x => x.Instructors).ToListAsync();
		//}
		#endregion

	}
}

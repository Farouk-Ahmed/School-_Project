using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entityes;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBasic;

namespace SchoolProject.Infrastructure.Reposatiry
{
	public class SubjectRepository : GenericRepos<Subjects>, ISubjectRepository
	{

		#region Fields
		private DbSet<Subjects> Subjects;
		#endregion
		#region Ctor
		public SubjectRepository(AppDBContext dbContext) : base(dbContext)
		{
			Subjects = dbContext.Set<Subjects>();
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

using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entityes;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBasic;

namespace SchoolProject.Infrastructure.Reposatiry
{
	public class DepartmentRepository : GenericRepos<Department>, IDepartmentRepository
	{

		#region Fields
		private DbSet<Department> departments;
		#endregion
		#region Ctor
		public DepartmentRepository(AppDBContext dbContext) : base(dbContext)
		{
			departments = dbContext.Set<Department>();
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

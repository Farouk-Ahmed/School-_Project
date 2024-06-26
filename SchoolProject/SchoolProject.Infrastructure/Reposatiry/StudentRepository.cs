using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entityes;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Reposatiry
{
	public class StudentRepository : GenericRepos<Student>, IStudentRepository
	{
		#region Fild
		private readonly DbSet<Student> _students;
		#endregion

		#region Ctor
		public StudentRepository(AppDBContext dbContext):base(dbContext) 
        {
			_students=dbContext.Set<Student>();
		}
		#endregion

		#region Handul Func
		public async Task<List<Student>> GetStudentsListAsync()
		{
			return await _students. Include(x=>x.Department).ToListAsync();	
		}
		#endregion
	}
}

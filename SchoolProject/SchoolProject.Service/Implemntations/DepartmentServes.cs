using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entityes;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstrcte;

namespace SchoolProject.Service.Implemntations
{
	public class DepartmentServes : IDepartmentServes
	{
		#region Fields
		private readonly IDepartmentRepository _departmentRepository;
		#endregion
		#region Ctor
		public DepartmentServes(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}
		#endregion
		#region Handle Func
		public async Task<Department> GetDepartmentById(int id)
		{
			var Student = await _departmentRepository.GetTableNoTracking()
					.Where(x => x.DID.Equals(id))
					.Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
					.Include(x => x.Instructors)
					.Include(x => x.Instructor).FirstOrDefaultAsync();
			return Student;
		}

		public async Task<bool> IsDepartmentExist(int departmentid)
		{
			return await _departmentRepository.GetTableNoTracking()
				.AnyAsync(x => x.DID == departmentid);
		}
		#endregion
	}
}

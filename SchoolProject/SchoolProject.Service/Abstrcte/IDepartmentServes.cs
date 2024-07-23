using SchoolProject.Data.Entityes;

namespace SchoolProject.Service.Abstrcte
{
	public interface IDepartmentServes
	{
		public Task<Department> GetDepartmentById(int id);
		public Task<bool> IsDepartmentExist(int departmentid);
	}
}

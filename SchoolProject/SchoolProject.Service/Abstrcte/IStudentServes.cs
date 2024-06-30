using SchoolProject.Data.Entityes;

namespace SchoolProject.Service.Abstrcte
{
	public interface IStudentServes
	{
		public Task<List<Student>> GetStudentsAsync();
		public Task<Student> GetStudentByIDsAsync(int id);
		public Task<string> AddAsync(Student student);
		public Task<bool> IsNameExist(string name);
		public Task<bool> IsNameExistExcludeSelf(string name, int id);
		public Task<string> EditAsync(Student student);
	}
}

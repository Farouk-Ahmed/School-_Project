using SchoolProject.Data.Entityes;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstrcte
{
	public interface IStudentServes
	{
		public Task<List<Student>> GetStudentsAsync();
		public Task<Student> GetStudentByIDIncludesAsync(int id);
		public Task<Student> GetByIDsAsync(int id);
		public Task<string> AddAsync(Student student);
		public Task<bool> IsNameExist(string name);
		public Task<bool> IsNameExistExcludeSelf(string name, int id);
		public Task<string> EditAsync(Student student);
		public Task<string> DeleteAsync(Student student);
		public IQueryable<Student> GetStudentsQueryable();
		public IQueryable<Student> FilterStudentsQueryable(StudentOrderingEnum orderingEnum, string search);

	}
}

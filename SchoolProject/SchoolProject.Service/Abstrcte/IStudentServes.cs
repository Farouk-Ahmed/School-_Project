﻿using SchoolProject.Data.Entityes;

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

	}
}

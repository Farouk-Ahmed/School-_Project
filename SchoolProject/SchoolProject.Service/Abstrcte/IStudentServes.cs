using SchoolProject.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstrcte
{
	public interface IStudentServes
	{
		public Task<List<Student>>GetStudentsAsync();
		public Task<Student>GetStudentByIDsAsync(int id);
		public Task<string> AddAsync(Student student);
	}
}

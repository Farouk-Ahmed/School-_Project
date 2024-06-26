using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entityes;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstrcte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implemntations
{
	public class StudentServes : IStudentServes
	{
		#region Fild
		private readonly IStudentRepository _studentRepository;
		#endregion
		#region Ctor
		public StudentServes(IStudentRepository studentRepository )
        {
			this._studentRepository = studentRepository;
		}

		
		#endregion
		#region Hundel Func
		public async Task<List<Student>> GetStudentsAsync()
		{
			 return await _studentRepository.GetStudentsListAsync();
		}

		public async Task<Student> GetStudentByIDsAsync(int id)
		{
			//var student=await _studentRepository.GetByIdAsync(id);
			//return student;
			var Student = _studentRepository.GetTableNoTracking()
				.Include(x => x.Department)
				.Where(x => x.StudID.Equals(id))
				.FirstOrDefault();
			return Student;
		}

		public async Task<string> AddAsync(Student student)
		{
			var CreateStudent = _studentRepository
				.GetTableNoTracking()
				.Where(x => x.Name.Equals(student.Name))
				.FirstOrDefault();
			//Check if The Name is Exist or not
			if (CreateStudent != null) return "Exist";
			//Added Student 
			await _studentRepository.AddAsync(student);
			return "Success";
		}
		#endregion

	}
}

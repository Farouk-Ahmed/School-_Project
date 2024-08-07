﻿using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entityes;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstrcte;

namespace SchoolProject.Service.Implemntations
{
	public class StudentServes : IStudentServes
	{
		#region Fild
		private readonly IStudentRepository _studentRepository;
		#endregion
		#region Ctor
		public StudentServes(IStudentRepository studentRepository)
		{
			this._studentRepository = studentRepository;
		}


		#endregion
		#region Hundel Func
		public async Task<List<Student>> GetStudentsAsync()
		{
			return await _studentRepository.GetStudentsListAsync();
		}

		public async Task<Student> GetStudentByIDIncludesAsync(int id)
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

			//Added Student 
			await _studentRepository.AddAsync(student);
			return "Success";
		}

		public async Task<bool> IsNameExist(string name)
		{
			var Student = _studentRepository
				.GetTableNoTracking()
				.Where(x => x.NameEn.Equals(name))
				.FirstOrDefault();
			//Check if The Name is Exist or not
			if (Student == null) return false;
			return true;
		}

		public async Task<bool> IsNameExistExcludeSelf(string name, int id)
		{
			var Student = await _studentRepository
				.GetTableNoTracking()
				.Where(x => x.NameEn.Equals(name) & !x.StudID.Equals(id))
				.FirstOrDefaultAsync();
			//Check if The Name is Exist or not
			if (Student == null) return false;
			return true;
		}

		public async Task<string> EditAsync(Student student)
		{
			await _studentRepository.UpdateAsync(student);
			return "Success";
		}

		public async Task<string> DeleteAsync(Student student)
		{
			var trans = _studentRepository.BeginTransaction();
			try
			{
				await _studentRepository.DeleteAsync(student);
				await trans.CommitAsync();
				return "Success";
			}
			catch
			{

				await trans.RollbackAsync();
				return "Falide";
			}

		}

		public async Task<Student> GetByIDsAsync(int id)
		{
			var student = await _studentRepository.GetByIdAsync(id);
			return student;
		}

		public IQueryable<Student> GetStudentsQueryable()
		{
			return _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
		}

		public IQueryable<Student> FilterStudentsQueryable(StudentOrderingEnum orderingEnum, string search)
		{
			var querable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
			if (search != null)
			{

				querable = querable.Where(x => x.NameEn.Contains(search) || x.Address.Contains(search));
			}
			switch (orderingEnum)
			{
				case StudentOrderingEnum.StudID:
					querable = querable.OrderBy(x => x.StudID);
					break;
				case StudentOrderingEnum.Name:
					querable = querable.OrderBy(x => x.NameEn);
					break;
				case StudentOrderingEnum.Address:
					querable = querable.OrderBy(x => x.Address);

					break;
				case StudentOrderingEnum.Phone:
					querable = querable.OrderBy(x => x.Phone);
					break;
				case StudentOrderingEnum.DepartmentName:
					querable = querable.OrderBy(x => x.Department.DNameEn);
					break;
			}
			return querable;
		}

		public IQueryable<Student> GetStudentsDepartmentByIdQueryable(int DID)
		{
			return _studentRepository.GetTableNoTracking().Where(x => x.DID.Equals(DID)).AsQueryable();
		}





		#endregion

	}
}

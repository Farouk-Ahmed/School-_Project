using SchoolProject.Data.Entityes;
using SchoolProject.Infrastructure.InfrastructureBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Abstracts
{
	public interface IStudentRepository: IGenericRepos<Student>
	{
		public Task<List<Student>>GetStudentsListAsync();
	}
}

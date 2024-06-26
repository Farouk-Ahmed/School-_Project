using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SchoolProject.Infrastructure.Data
{
	public class AppDBContext:DbContext
	{

        public AppDBContext()
        {
            
        }
        public AppDBContext(DbContextOptions<AppDBContext> Options):base(Options) 
        {
            
        }
        public DbSet<Student>Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set;}
        public DbSet<StudentSubject> StudentSubjects { get; set; }

    }
}

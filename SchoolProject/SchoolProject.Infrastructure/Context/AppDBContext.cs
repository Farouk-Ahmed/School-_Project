using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entityes;

namespace SchoolProject.Infrastructure.Data
{
	public class AppDBContext : DbContext
	{

		public AppDBContext()
		{

		}
		public AppDBContext(DbContextOptions<AppDBContext> Options) : base(Options)
		{

		}
		public DbSet<Student> Students { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Subjects> Subjects { get; set; }
		public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
		public DbSet<StudentSubject> StudentSubjects { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DepartmetSubject>().HasKey(x => new { x.SubID, x.DID });


			modelBuilder.Entity<Ins_Subject>().HasKey(x => new { x.SubId, x.InsId });


			modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.SubID, x.StudID });

			modelBuilder.Entity<Instructor>().HasOne(x => x.Supervisor)
				.WithMany(x => x.Instructors).HasForeignKey(x => x.SupervisorId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Department>().HasOne(x => x.Instructor)
				.WithOne(x => x.departmentManager)
				.HasForeignKey<Department>(x => x.InsManager)
				.OnDelete(DeleteBehavior.Restrict);


			base.OnModelCreating(modelBuilder);
		}

	}
}

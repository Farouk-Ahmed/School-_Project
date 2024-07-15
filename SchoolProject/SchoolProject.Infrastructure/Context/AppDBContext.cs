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
			modelBuilder.HasDefaultSchema("School");
			#region Studen
			modelBuilder.Entity<Student>().Property(s => s.NameEn).HasColumnName("Name in English").HasMaxLength(50);
			modelBuilder.Entity<Student>().Property(s => s.NameAr).HasColumnName("Name in Arabic ").HasMaxLength(50);
			modelBuilder.Entity<Student>().Property(s => s.Address).HasMaxLength(50);
			modelBuilder.Entity<Student>().Property(s => s.Phone).HasMaxLength(14);
			#endregion

			#region Departmet
			modelBuilder.Entity<Department>().Property(d => d.DNameEn).HasColumnName("Name in English").HasMaxLength(50);
			modelBuilder.Entity<Department>().Property(d => d.DNameAr).HasColumnName("Name in Arabic ").HasMaxLength(50);

			#endregion

			#region Instructor
			modelBuilder.Entity<Instructor>().Property(i => i.ENameEn).HasColumnName("Name in English").HasMaxLength(50);
			modelBuilder.Entity<Instructor>().Property(i => i.ENameAr).HasColumnName("Name in Arabic ").HasMaxLength(50);
			modelBuilder.Entity<Instructor>().Property(i => i.Address).HasMaxLength(50);
			modelBuilder.Entity<Instructor>().Property(i => i.Position).HasMaxLength(50);
			#endregion
			#region Subject
			modelBuilder.Entity<Subjects>().Property(sub => sub.SubjectNameEn).HasColumnName("Name in English").HasMaxLength(50);
			modelBuilder.Entity<Subjects>().Property(sub => sub.SubjectNameAr).HasColumnName("Name in Arabic ").HasMaxLength(50);
			#endregion





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

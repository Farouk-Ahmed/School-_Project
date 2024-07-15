using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entityes
{
	public class Department : LocalizableEntitiy
	{
		public Department()
		{
			Students = new HashSet<Student>();
			DepartmentSubjects = new HashSet<DepartmetSubject>();
		}
		[Key]
		public int DID { get; set; }
		public string? DNameEn { get; set; }
		public string? DNameAr { get; set; }
		public int? InsManager { get; set; }

		[InverseProperty("Department")]
		public virtual ICollection<Student> Students { get; set; }
		[InverseProperty("Department")]
		public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
		[InverseProperty("department")]
		public virtual ICollection<Instructor> Instructors { get; set; }
		[ForeignKey("InsManager")]
		[InverseProperty("departmentManager")]
		public virtual Instructor? Instructor { get; set; }
	}
}

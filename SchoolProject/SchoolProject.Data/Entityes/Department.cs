using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;

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
		[StringLength(500)]
		public string DNameEn { get; set; }
		public string DNameAr { get; set; }
		public virtual ICollection<Student> Students { get; set; }
		public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
	}
}

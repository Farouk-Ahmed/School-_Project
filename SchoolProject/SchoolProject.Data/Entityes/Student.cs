using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entityes
{
	public class Student : LocalizableEntitiy
	{
		public Student()
		{
			StudentSubjects = new HashSet<StudentSubject>();
		}
		[Key]
		public int StudID { get; set; }
		public string? NameEn { get; set; }
		public string? NameAr { get; set; }

		public string? Address { get; set; }

		public string? Phone { get; set; }
		public int? DID { get; set; }

		[ForeignKey("DID")]
		[InverseProperty("Students")]
		public virtual Department? Department { get; set; }
		[InverseProperty("Student")]
		public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
	}
}

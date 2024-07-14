using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entityes
{
	public class DepartmetSubject
	{
		[Key]
		public int DeptSubID { get; set; }
		public int DID { get; set; }
		public int SubID { get; set; }

		[ForeignKey("DID")]
		[InverseProperty("DepartmentSubjects")]
		public virtual Department? Department { get; set; }

		[ForeignKey("SubID")]
		[InverseProperty("DepartmetsSubjects")]
		public virtual Subjects Subject { get; set; }
	}
}

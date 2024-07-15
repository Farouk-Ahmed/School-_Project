﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entityes
{
	public class Subjects
	{
		public Subjects()
		{
			StudentsSubjects = new HashSet<StudentSubject>();
			DepartmetsSubjects = new HashSet<DepartmetSubject>();
			Ins_Subjects = new HashSet<Ins_Subject>();
		}
		[Key]
		public int SubID { get; set; }
		[StringLength(500)]
		public string? SubjectNameAr { get; set; }
		public string? SubjectNameEn { get; set; }
		public int? Period { get; set; }
		[InverseProperty("Subject")]
		public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
		[InverseProperty("Subject")]
		public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }
		[InverseProperty("subject")]
		public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
	}
}

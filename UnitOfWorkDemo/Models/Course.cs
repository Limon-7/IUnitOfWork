using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models
{
	public class Course
	{
		public int CourseID { get; set; }
		public string Title { get; set; }
		public int Credits { get; set; }
		 /*
		  *   many relationship with enrollment entity
		  */
		public ICollection<Enrollment> Enrollments { get; set; }
	}
}

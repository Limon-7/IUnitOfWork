using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models
{
	public class CourseInstructor
	{
		public int CourseID { get; set; }
		public Course Course { get; set; }

		public int InstructorId { get; set; }
		public Instructor Instructor { get; set; }
	}
}

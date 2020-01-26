using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Dtos
{
	public class InstructorIndexDto
	{
		public IEnumerable<Instructor> Instructors { get; set; }
		public IEnumerable<Course> Courses { get; set; }
		public IEnumerable<Enrollment> Enrollments { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models
{
	public class Student
	{
		public int Id { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime? EnrollmentDate { get; set; }
	   /*
	    * One student has a collection of entity
		* *
		* 
		*/
		public ICollection<Enrollment> Enrollments { get; set; }
	}
}

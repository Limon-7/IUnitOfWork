using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models
{
	public class Student
	{
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		[Display(Name = "Last Name")]
		public String LastName { get; set; }
		[Required]
		[StringLength(50)]
		[Display(Name = "First Name")]
		public string FirstNmae { get; set; }
		[Display(Name = "Full Name")]
		public string FullName
		{
			get
			{
				return FirstNmae + " " + LastName;
			}
		}
		public DateTime? EnrollmentDate { get; set; }
		/*	 MANY-TO-ONE(<Student>1------*<Enrollment>)
	   * <Enrollment> Entity is Dependent entity create one-to-many reltionship with principle<Student> Enitity and <Enrollment> Entity holds the foreign key
	   * 	many-to-one relationship with Instructors
	   * 	multiple <Enrollment> entities allow us to add to a <Student> Entity  	
	   */
		public ICollection<Enrollment> Enrollments { get; set; }
	}
}

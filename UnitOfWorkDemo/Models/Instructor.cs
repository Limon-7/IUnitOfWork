using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models
{
	public class Instructor
	{
		public int ID { get; set; }
		[Required]
		[StringLength(50)]
		[Display(Name = "Last Name")]
		public String LastName { get; set; }
		[Required]
		[StringLength(50)]
		[Display(Name = "First Name")]
		public string FirstNmae { get; set; }
		[Display(Name = "Full Name")]
		public string FullName {
			get
			{
				return FirstNmae + " " + LastName;
			}
		}
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
		[Display(Name ="Hire Date")]
		public DateTime HireDate { get; set; }
		//<Instructor> entity create many to may realtionship with <Course> Entity
		/*	MANY-TO-MANY(<Instructor>*------*<Course>)
		 *	SO WE CREATE ANOTHER CLASS THAT JOINT TWO TABLE
		 * <Instructor> entity create many-to-many reltionship with <Course> Enitity and this will create composite foreign key	& make new table
		 * we need to use fluent api to create many-to-many relationship
		 * 	many-to-many relationship with Instructors
		 * 	multiple <Course> entities allow us to add to multiple <Instructor> Entities  
		 */
		//public ICollection<Course> Courses{ get; set; }
		public ICollection<CourseInstructor> CourseInstructors { get; set; }

		/* ONE-TO-MANY(<Department>*----0..1<Instructor>)
		 * <Department>Dependent entity create one-to-many reltionship with principle<Instructor> Enitity and and <Department> entity holds the foreign key
		 * <Department> entity one-to-many relationship with <Instructor> Entity
		 * multiple <Department> Entities allow us to add to a  <Instructor> Entity
		 */
		public ICollection<Department> Departments { get; set; }

		/*	ONE-TO-ONe/ZERO(<Instructor>1..0------1<OfficeAssignment>)
		 *	WE MUST USE FLUENT API CREATING ONE-TO-ONE OR ONE-TO-ZERO relationship
		 * <OfficeAssignment> dependent entity and <Instructor> Is the principle Entity
		 * One-to-One or one-to-zero(Instrutor..1____0.1 OfficeAssignment)
		 * Office entity will only avaiable if Instructor is avaiable
		 */
		public OfficeAssignment OfficeAssignment { get; set; }
	}
}

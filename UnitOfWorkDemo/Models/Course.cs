using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models
{
	public class Course
	{
		public int CourseID { get; set; }
		[StringLength(50, MinimumLength = 3)]
		public string Title { get; set; }
		[Range(0, 5)]
		public int Credits { get; set; }
		/*	MANY-TO-ONE(<COURSE>1------*<Enrollment>)
		 * <Enrollment>Dependent entity create one-to-many reltionship with principle<Course> Enitity and and <Enrollment> entity holds the foreign key
		 * Enrollment>Dependent entity creates one-to-many relationship with <enrollment> entity
		 * multiple <Enrollment> entities to a <Course> Entity 
	    */
		public ICollection<Enrollment> Enrollments { get; set; }

		//<Course> entity create many to may realtionship with <Instructor> Entity
		/*	MANY-TO-MANY(<Instructor>*------*<Course>)
		 *	SO WE CREATE ANOTHER CLASS THAT JOINT TWO TABLE
		 * <Instructor> entity create many-to-many reltionship with <Course> Enitity and this will create composite foreign key	& make new table
		 * we need to use fluent api to create many-to-many relationship
		 * 	many-to-many relationship with Instructors
		 * 	multiple <Instructor> entities allow us to add to multiple <Course> Entities  
		 */
		//public ICollection<Instructor> Instructors { get; set; }
		public ICollection<CourseInstructor> CourseInstructors { get; set; }

		/*	ONE-TO-MANY(<Course>*------1<Department>)
		 * <Course>Dependent entity create one-to-many reltionship with principle<Department> Enitity and and <Course> entity holds the foreign key
		 * one-to-many relationship with <Department> Entity
		 * multiple <Course> Entities allow us to add to a  <Department> Entity
		 */
		public int? DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}

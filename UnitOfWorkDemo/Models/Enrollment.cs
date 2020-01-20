using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models
{
	public enum Grade { A,B,C,D,F }
	public class Enrollment
	{
		public int Id { get; set; }

		[DisplayFormat(NullDisplayText ="No Grade")]
		public Grade? Grade { get; set; }
		/*	ONE-TO-MANY(<Enrollment>*------1<Student>)
		 * <Enrollment> Dependent entity create one-to-many reltionship with principle<Student> Enitity and and <Enrollment> entity holds the foreign key
		 * <Enrollment> Entity creates one-to-many relationship with <Student> Entity
		 * multiple <Enrollment> Entities allow us to add to a  <Student> Entity
		 */
		public int StudentId { get; set; }
		public Student Student { get; set; }

		/*	ONE-TO-MANY(<Enrollment>*------1<COURSE>)
		 * <Enrollment> Dependent entity create one-to-many reltionship with principle<Course> Enitity and and <Enrollment> entity holds the foreign key
		 * one-to-Many relationship with <Course> entity
		 * multiple <Enrollment> entities allow us to add to a <Course> Entity 
	    */
		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}

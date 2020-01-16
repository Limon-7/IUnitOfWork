using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models
{
	public enum Grade { A,B,C,D,F }
	public class Enrollment
	{
		public int Id { get; set; }
		public Grade? Grade { get; set; }
		/*
		 * 	one enrollment entity will be for one student entity
		 * 	one to many relationship with student entity
		 */
		public int StudentId { get; set; }
		public Student Student { get; set; }

		/*
		 * 
		 * one to may relation with course entity
		 */
		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}

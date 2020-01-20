using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models
{
	public class Department
	{
		public int Id { get; set; }
		[StringLength(50, MinimumLength =3)]
		public string Name { get; set; }
		[DataType(DataType.Currency)]
		public decimal Budget { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
		[Display(Name ="Start Date")]
		public DateTime StartDate { get; set; }


		/*	ONE-TO-MANY(<Course>*------1<Department>)
		* <Course>Dependent entity create one-to-many reltionship with principle<Department> Enitity and and <Course> entity holds the foreign key
		* many-to-one relationship with <Course> entity
		* multiple <Course> entities allow us to add to a <Department> Entity 
	   */
		public ICollection<Course> Courses { get; set; }

		/*
		 * ONE-TO-MANY(<Department>*----0..1<Instructor>)
		 * <Department>Dependent entity create one-to-many reltionship with principle<Instructor> Enitity and and <Department> entity holds the foreign key
		 * <Department>Dependent entity one-to-many relationship with <Instructor> Entity
		 * multiple <Department> Entities allow us to add to a  <Instructor> Entity
		 */
		public int? InstructorID { get; set; }
		public Instructor Instructor { get; set; }

	}
}

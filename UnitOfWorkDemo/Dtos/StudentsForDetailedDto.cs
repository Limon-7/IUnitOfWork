using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Dtos
{
	public class StudentsForDetailedDto
	{
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
		[DataType(DataType.Date)]
		public DateTime? EnrollmentDate { get; set; }
		public int Count { get; set; }
		public ICollection<Enrollment> Enrollments { get; set; }
	}
}

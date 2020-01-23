using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Dtos
{
	public class StudentForCreationDto
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
		
		//public string FullName
		//{
		//	get
		//	{
		//		return FirstNmae + " " + LastName;
		//	}
		//}
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
		public DateTime? EnrollmentDate { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Dtos
{
	public class StudentsForEditDto
	{
		[Required]
		[StringLength(50)]
		[Display(Name = "Last Name")]
		public String LastName { get; set; }
		[Required]
		[StringLength(50)]
		[Display(Name = "First Name")]
		public string FirstNmae { get; set; }
		
	}
}

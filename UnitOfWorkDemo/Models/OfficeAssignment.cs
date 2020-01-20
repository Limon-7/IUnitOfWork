using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models
{
	public class OfficeAssignment
	{
		/*	Convention Way
		 * 	[key]
		 * 	[ForeignKey(Instructor)]
		 */
		public int InstructorId { get; set; }
		public string Location { get; set; }

		public Instructor Instructor { get; set; }
		/* WE MUST USE FLUENT API CREATING ONE-TO-ONE OR ONE-TO-ZERO relationship
		 * ONE/ZERO-TO-ONE(<OfficeAssignment>1------0..1<Instrutor>)
		 * <OfficeAssignment> dependent entity and Instructor Is the principle Entity
		 * Office entity will only avaiable if Instructor is avaiable 
		 */
	}
}

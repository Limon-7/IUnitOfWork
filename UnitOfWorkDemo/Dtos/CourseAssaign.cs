using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Dtos
{
	public class CourseAssaign
	{
		public int CourseId { get; set; }
		public string Title { get; set; }
		public bool Assaigned { get; set; }
	}
}

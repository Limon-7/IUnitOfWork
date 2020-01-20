using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Data.Repository
{
	public class StudentRepository : GenericRepository<Student>, IStudentRepository
	{
		public StudentRepository(ApplicationDbContext context) : base(context)
		{
				
		}

		public ApplicationDbContext ApplicationDbContext
		{
			get
			{
				return ApplicationDbContext as ApplicationDbContext;

			}
		}
	}
}

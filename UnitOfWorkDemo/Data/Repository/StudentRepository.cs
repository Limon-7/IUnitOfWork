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
		private readonly ApplicationDbContext _context;

		public StudentRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public ApplicationDbContext ApplicationDbContext
		{
			get
			{
				return ApplicationDbContext as ApplicationDbContext;

			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Student> StudentWithEnrollment(int id)
		{
			return await _context.Students.Include(p => p.Enrollments).ThenInclude(p => p.Course).ThenInclude(p => p.Department).FirstOrDefaultAsync(p => p.Id == id);

		}
	}
}

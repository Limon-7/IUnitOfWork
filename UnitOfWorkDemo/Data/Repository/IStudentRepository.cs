using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Data.Repository
{
	public interface IStudentRepository:IGenericRepository<Student>
	{
		Task<Student> StudentWithEnrollment(int id);
	}
}

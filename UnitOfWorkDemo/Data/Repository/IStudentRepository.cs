using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Data.Repository
{
	interface IStudentRepository:IGenericRepository<Student>
	{
	}
}

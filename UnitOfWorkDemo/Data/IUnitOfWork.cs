using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data.Repository;

namespace UnitOfWorkDemo.Data
{
	public interface IUnitOfWork  :IDisposable
	{
		IStudentRepository Students { get; }
		Task<int> Complete();
	}
}

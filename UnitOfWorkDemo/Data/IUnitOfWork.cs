using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data.Repository;

namespace UnitOfWorkDemo.Data
{
	interface IUnitOfWork  :IDisposable
	{
		StudentRepository Students { get; }
		int Complete();
	}
}

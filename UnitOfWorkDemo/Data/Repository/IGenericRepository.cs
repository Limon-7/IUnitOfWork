using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Data.Repository
{
	public interface IGenericRepository<TEntity> where TEntity:class
	{
		TEntity Get(int id);
		Task <IEnumerable<TEntity>> GetAll();
		IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predict);
		TEntity SingleOrDefault(Expression<Func<TEntity,bool>> predict);

		Task Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);

		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);

	}	  
}

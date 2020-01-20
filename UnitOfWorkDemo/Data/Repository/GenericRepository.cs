using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Data.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly ApplicationDbContext _context;

		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<TEntity> GetById(int id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public async Task <IEnumerable<TEntity>> GetAll()
		{
			
			return await _context.Set<TEntity>().ToListAsync().ConfigureAwait(true);
		}

		

		public  IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predict)
		{
			return  _context.Set<TEntity>().Where(predict);
		}

		public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predict)
		{
			return  _context.Set<TEntity>().FirstOrDefault(predict);
		}

		public void Add(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().AddRange(entities);
		}

		public void Remove(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().RemoveRange(entities);
		}

		public  void Modify(TEntity entity)
		{
			 _context.Set<TEntity>().Update(entity);
		}
		/*
 * without task asyn
 public TEntity Get(int id)
{
	return _context.Set<TEntity>().Find(id);
}

public  IEnumerable<TEntity> GetAll()
{
 return	 _context.Set<TEntity>().ToList();
}

public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predict)
{
	return _context.Set<TEntity>().Where(predict);
}

public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predict)
{
	return _context.Set<TEntity>().FirstOrDefault(predict);
}

public async Task Add(TEntity entity)
{
	await _context.Set<TEntity>().AddAsync(entity);
}

public void AddRange(IEnumerable<TEntity> entities)
{
	_context.Set<TEntity>().AddRange(entities);
}

public void Remove(TEntity entity)
{
	_context.Set<TEntity>().Remove(entity);
}

public void RemoveRange(IEnumerable<TEntity> entities)
{
	_context.Set<TEntity>().RemoveRange(entities);
}
*/

	}
}

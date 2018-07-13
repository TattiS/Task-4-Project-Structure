using System;
using System.Collections.Generic;

namespace DALProject.Repositories
{
	public interface IGenRepository<TEntity> where TEntity : class
	{
		List<TEntity> GetAll();
		TEntity GetById(int id);
		List<TEntity> GetBy(Func<TEntity,bool> predicate);
		void Create(TEntity entity);
		void Insert(TEntity entity);
		void Delete(int id);
		void Delete(TEntity entityToRemove);
		void Update(TEntity entity);
		
	}
	
}
using DALProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DALProject.Repositories
{
	public class GenRepository<TEntity> : IGenRepository<TEntity> where TEntity : BaseEntity
	{
		protected readonly IEnumerable<TEntity> dataSet;
		
		public GenRepository(IEnumerable<TEntity> data)
		{
			this.dataSet = data;
		}

		public List<TEntity> GetAll()
		{
			return this.dataSet.ToList();
		}
		
		public TEntity GetById(int id)
		{
			//return this.dataSet.Find(ent =>ent.Id == id);		
			return this.dataSet.FirstOrDefault(ent => ent.Id == id);
		}
		public List<TEntity> GetBy(Func<TEntity, bool> predicate)
		{
			return dataSet.Where(predicate).ToList();
			
		}
		public void Create(TEntity entity)
		{
			if (entity != null)
			{
				int idForNew = dataSet.Max(p => p.Id) + 1;
				entity.Id = idForNew;
				if (!dataSet.Contains(entity))
				{
					//dataSet.Add(entity);
					dataSet.ToList().Add(entity);
				}
				else
				{
					throw new Exception("Can't add a new item: Such item is a dublicate of the existing one.");
				}

				
			}
			else
			{
				throw new ArgumentNullException();
			}
			
		}
		public void Insert(TEntity entity)
		{
			if (entity != null)
			{
				var changedItem = dataSet.FirstOrDefault(ent => ent.Id == entity.Id);
				if (changedItem != null)
				{
					//dataSet.Remove(changedItem);
					//dataSet.Add(entity);
					dataSet.ToList().Remove(changedItem);
					dataSet.ToList().Add(entity);
				}
			}
			else
			{
				throw new ArgumentNullException();
			}
		}

		public void Delete(int id)
		{
			//TEntity entityToRemove = dataSet.Find(entity => entity.Id==id);
			TEntity entityToRemove = dataSet.First(entity => entity.Id == id);
			if (entityToRemove != null)
			{
				Delete(entityToRemove);
			}
			
		}

		public void Delete(TEntity entityToRemove)
		{
			//dataSet.Remove(entityToRemove);
			dataSet.ToList().Remove(entityToRemove);
		}
		public void DeleteAll(Predicate<TEntity> predicate)
		{
			//dataSet.RemoveAll(predicate);
			dataSet.ToList().RemoveAll(predicate);
		}

		public void Update(TEntity entity)
		{
			//dataSet.Update(entity);
			//throw new System.NotImplementedException();
		}

		public void SaveChanges()
		{
			//dataSet.Save();
			throw new System.NotImplementedException();
		}

		
	}

}

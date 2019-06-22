
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected FantasticReads Context;
		protected DbSet<T> DbSet { get { return Context.Set<T>(); } }

		public BaseRepository()
		{
			Context = new FantasticReads();
		}

		public void Create(T item)
		{
			DbSet.Add(item);
			Context.SaveChanges();
		}

		public bool DeleteByID(int id)
		{
			bool isDeleted = false;
			T item = DbSet.Find(id);
			if(item!=null)
			{
				DbSet.Remove(item);
				isDeleted = true;
			}
			Context.SaveChanges();
			return isDeleted;
		}

		public void Edit(T item, Func<T, bool> findByIDPredicate)
		{
			var local = Context.Set<T>().Local.FirstOrDefault(findByIDPredicate);
			if(local!=null)
			{
				Context.Entry(local).State = EntityState.Detached;
			}
			Context.Entry(item).State = EntityState.Modified;
			Context.SaveChanges();
		}

		public List<T> GetAll()
		{
			return DbSet.ToList();
		}


		public T GetByID(int id)
		{
			return DbSet.Find(id);
		}

		public abstract void Save(T item);		
	}
}

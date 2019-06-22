using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public interface IBaseRepository<T> where T: class
	{
		List<T> GetAll();
		T GetByID(int id);
		void Create(T item);
		void Edit(T item, Func<T, bool> findByIDPredicate);
		bool DeleteByID(int id);
		void Save(T item);
	}
}

using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class BookRepository : BaseRepository<Book>
	{
		public override void Save(Book book)
		{
			if(book.ID==0)
			{
				base.Create(book);
			}
			else
			{
				base.Edit(book, item => item.ID == book.ID);
			}
		}
		public List<Book> GetRecent(int n)
		{
			return DbSet.Take(n).OrderByDescending(book => book.ID).ToList();
		}
		public List<Book> GetByAuthor(List<int> authors)
		{
			List<Book> books = new List<Book>();
			foreach(int id in authors)
			{
				List<Book> checkList = Context.Books.Where(p => p.AuthorID == id).Select(p => p).ToList();
				if(checkList!=null)
				{
					books.AddRange(checkList);
				}
			}
			return books;
		}
	}
}

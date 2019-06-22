using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class AuthorRepository : BaseRepository<Author>
	{
		public override void Save(Author author)
		{
			if(author.ID==0)
			{
				base.Create(author);
			}
			else
			{
				base.Edit(author, item => item.ID == author.ID);
			}
		}
	}
}

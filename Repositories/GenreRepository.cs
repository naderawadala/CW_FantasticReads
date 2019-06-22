using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class GenreRepository:BaseRepository<Genre>
	{
		public override void Save(Genre genre)
		{
			if (genre.ID == 0)
			{
				base.Create(genre);
			}
			else
			{
				base.Edit(genre, item => item.ID == genre.ID);
			}
		}
	}
}

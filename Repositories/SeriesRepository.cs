using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class SeriesRepository:BaseRepository<Series>
	{
		public override void Save(Series series)
		{
			if (series.ID == 0)
			{
				base.Create(series);
			}
			else
			{
				base.Edit(series, item => item.ID == series.ID);
			}
		}
	}
}

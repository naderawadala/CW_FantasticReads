using CW_FantasticReads.Helpers;
using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CW_FantasticReads.Models
{
	public class HomeBookViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string ImagePath { get; set; }
	}
	public class HomeViewModel
	{
		public List<HomeBookViewModel> bookList { get; set; }

		public HomeViewModel()
		{
			bookList = new List<HomeBookViewModel>();
		}

		public HomeViewModel(List<Book> allBooks):this()
		{
			foreach(Book book in allBooks)
			{
				string imgFullPath;
				if (!string.IsNullOrWhiteSpace(book.ImageName))
				{
					imgFullPath = Path.Combine(Constants.ImagesDirectory, book.ImageName);
				}
				else
				{
					imgFullPath = Path.Combine(Constants.ImagesDirectory, Constants.NoCoverPath);
				}
				HomeBookViewModel item = new HomeBookViewModel();
				item.ID = book.ID;
				item.Name = book.Name;
				item.ImagePath = imgFullPath;
				bookList.Add(item);
			}
		}
			
	}
}
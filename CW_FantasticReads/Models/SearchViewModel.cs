using CW_FantasticReads.Helpers;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace CW_FantasticReads.Models
{
	public class SearchViewModel
	{
		public int BookID { get; set; }
		[MinLength(5, ErrorMessage = "Please enter at least five characters")]
		[MaxLength(50, ErrorMessage = "Limit exceeded, do not go past fifty characters!")]
		public string BookName { get; set; }
		public string ImageURL { get; set; }

		public SearchViewModel(Book book)
		{
			this.BookID = book.ID;
			this.BookName = book.Name;
			string fullPath;
			if (string.IsNullOrEmpty(book.ImageName))
			{
				fullPath = Path.Combine(Constants.ImagesDirectory, Constants.NoCoverPath);
			}
			else
			{
				fullPath = Path.Combine(Constants.ImagesDirectory, book.ImageName);
			}
			this.ImageURL = fullPath;
		}
		public SearchViewModel() { }
	}
}
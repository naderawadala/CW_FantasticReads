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
	public class CreateBookViewModel
	{
		[Required]
		[MinLength(5, ErrorMessage = "Please enter at least five characters")]
		[MaxLength(50, ErrorMessage = "Limit exceeded, do not go past fifty characters!")]
		public string Name { get; set; }
		[Required]
		public int Author { get; set; }
		[Required]
		public int Genre { get; set; }
		[Required]
		public int Series { get; set; }
		[Required]
		[Range(1, 1000, ErrorMessage = "Price must be between the range of 1 and 1000")]
		public double Price { get; set; }
		[Required]
		[Range(50, 5000, ErrorMessage = "Pages must be between the range of 50 and 5000")]
		public int Pages { get; set; }
		public string ImageName { get; set; }

		public string ImagePath { get; set; }


		public CreateBookViewModel() { }
		public CreateBookViewModel(Book dbBook)
		{
			this.Name = dbBook.Name;
			this.Author = dbBook.Author.ID;
			this.Genre = dbBook.Genre.ID;
			this.Series = dbBook.Series.ID;
			this.Price = dbBook.Price;
			this.Pages = dbBook.Pages;
			this.ImageName = dbBook.ImageName;
			this.ImagePath = Path.Combine(Constants.ImagesDirectory, this.ImageName);
		}
	}
}
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CW_FantasticReads.Models
{
	public class AuthorViewModel
	{
		public int ID { get; set; }
		[Required]
		[MinLength(5,ErrorMessage ="Please enter at least five characters")]
		[MaxLength(50,ErrorMessage ="Limit exceeded, do not go past fifty characters!")]
		public string Name { get; set; }
		public AuthorViewModel()
		{
			
		}
		public AuthorViewModel(Author dbAuthor)
		{
			this.ID = dbAuthor.ID;
			this.Name = dbAuthor.Name;
		}
	}
}
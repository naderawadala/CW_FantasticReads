using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CW_FantasticReads.Models
{
	public class CreateSeriesViewModel
	{
		[Required]
		[MinLength(5, ErrorMessage = "Please enter at least five characters")]
		[MaxLength(50, ErrorMessage = "Limit exceeded, do not go past fifty characters!")]
		public string Name { get; set; }
		public CreateSeriesViewModel()
		{

		}
		CreateSeriesViewModel(string name)
		{
			this.Name = name;
		}
	}
}
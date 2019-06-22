using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CW_FantasticReads.Models
{
	public class LoginViewModel
	{
		[Required]
		[StringLength(25, ErrorMessage = "A username does not have more than 25 characters!")]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
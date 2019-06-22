using CW_FantasticReads.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CW_FantasticReads.Models
{
	public class RegisterViewModel
	{
		[Required]
		[MinLength(5, ErrorMessage = "Can't have a username with less than 5 characters!")]
		[MaxLength(25,ErrorMessage ="Can't have a username with more than 25 characters!")]
		public string Username { get; set; }
		[Required]
		[MinLength(5, ErrorMessage = "Can't have a password with less than 5 characters!")]
		[MaxLength(25, ErrorMessage = "Can't have a password with more than 25 characters!")]
		[DataType(DataType.Password)]
		[CustomPassword]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Compare("Password",ErrorMessage ="Passwords do not match!")]
		public string ConfirmPassword { get; set; }
	}
}
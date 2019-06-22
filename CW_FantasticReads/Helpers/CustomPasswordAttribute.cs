using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CW_FantasticReads.Helpers
{
	public sealed class CustomPasswordAttribute : ValidationAttribute
	{
		public CustomPasswordAttribute()
		{
			ErrorMessage = "Password should contain both digits and letters";
		}
		
		public override bool IsValid(object value)
		{
			bool result = false;
			string text = value as string;
			if (string.IsNullOrEmpty(text) == false)
			{
				List<char> charsList = text.ToCharArray().ToList();
				bool hasDigits = charsList.Any(c => char.IsDigit(c));
				bool hasLetters = charsList.Any(c => char.IsLetter(c));
				if (hasDigits && hasLetters)
				{
					result = true;
				}
			}

			return result;
		}
	}

}
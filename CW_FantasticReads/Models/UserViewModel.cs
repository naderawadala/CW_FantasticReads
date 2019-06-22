using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW_FantasticReads.Models
{
	public class UserViewModel
	{
		public int ID { get; set; }
		public string Username { get; set; }
		public bool IsAdmin { get; set; }
		
		public UserViewModel()
		{

		}
		public UserViewModel(User user)
		{
			this.ID = user.UserID;
			this.Username = user.Username;
			this.IsAdmin = user.IsAdmin;
		}
	}

}
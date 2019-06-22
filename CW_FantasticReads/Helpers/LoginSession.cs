using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW_FantasticReads.Helpers
{
	public class LoginSession
	{
		public int UserID { get; set; }
		public string Username { get; set; }
		public bool IsAuthenticated { get; set; }
		public bool IsAdministrator { get; set; }

		private LoginSession()
		{

		}

		public static LoginSession Current
		{
			get
			{
				LoginSession loginSession = (LoginSession)HttpContext.Current.Session["LoginUser"];
				if (loginSession == null)
				{
					loginSession = new LoginSession();
					HttpContext.Current.Session["LoginUser"] = loginSession;
				}
				return loginSession;
			}
		}

		public void SetCurrentUser(int userID,string username, bool isAdministrator)
		{
			this.IsAuthenticated = true;
			this.IsAdministrator = isAdministrator;
			this.UserID = userID;
			this.Username = username;
		}
		public void Logout()
		{
			this.IsAuthenticated = false;
			this.IsAdministrator = false;
			this.UserID = 0;
			this.Username = string.Empty;
		}
	}
}
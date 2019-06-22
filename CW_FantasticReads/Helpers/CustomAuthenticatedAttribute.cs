using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CW_FantasticReads.Helpers
{
	public sealed class CustomAuthenticatedAttribute : FilterAttribute, IAuthorizationFilter
	{
		
		
			public bool AllowUserAccess { get; set; }

			public void OnAuthorization(AuthorizationContext filterContext)
			{
				if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any()
					|| filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any())
				{
					return;
				}

				if (LoginSession.Current.IsAuthenticated == false)
				{
					filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "AccessDenied" }));
				}
				
			}
		
	}
}
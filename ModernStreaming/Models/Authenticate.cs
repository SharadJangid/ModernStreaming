using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModernStreaming.Models
{
    public class Authenticate : ActionFilterAttribute
    {
        // This code block executes before any controller's action is executed
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Get the current http session context
            HttpContext ctx = HttpContext.Current;

            //Check if the user session is expired
            if (UserLogin.IsUserSessionExpired() == true)
            {
                // If user session is expired then Redirect to Login Page.
                filterContext.Result = new RedirectResult("~/UserLogin/Login?logout_parameter=s");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
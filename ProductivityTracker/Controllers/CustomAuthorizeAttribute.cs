using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductivityTracker.Controllers
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["UserID"];
            if (user == null)
            {
                //filterContext.Result = new RedirectResult(string.Format("/Login", filterContext.HttpContext.Request.Url.AbsolutePath));
                filterContext.Result = new RedirectResult("/Login");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FBARefund.CustomAttributes
{
    public class AccessDeniedAuthorizeAttribute : AuthorizeAttribute
    {
        public string AccessDeniedController { get; set; }
        public string AccessDeniedAction { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = "Account", Action = "Login" }));
                return;
            }

            if (filterContext.Result is HttpUnauthorizedResult)
            {

                if (String.IsNullOrWhiteSpace(AccessDeniedController) || String.IsNullOrWhiteSpace(AccessDeniedAction))
                {
                    AccessDeniedController = "Account";
                    AccessDeniedAction = "Denied";
                }

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = AccessDeniedController, Action = AccessDeniedAction }));
            }
        }
    }
}
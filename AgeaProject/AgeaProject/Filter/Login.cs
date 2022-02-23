using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Filter
{
    public class Login : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Middleware Started");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string sess = context.HttpContext.Session.GetString("user-id");
            if (sess is null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(
                                    new
                                    {
                                        controller = "Auth",
                                        action = "Index",
                                        area = "Admin"
                                    }));
            }

        }
    }
}

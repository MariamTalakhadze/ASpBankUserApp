using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASpBankUserApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "User", action = "Login" }
            );
            routes.MapRoute(
                name: "Index",
                url: "{controller}/{action}",
                defaults: new { controller = "User", action = "Index"}
            );
            routes.MapRoute(
               name: "Registration",
               url: "{controller}/{action}",
               defaults: new { controller = "User", action = "Registration"}
           );
            routes.MapRoute(
               name: "OperationRegistration",
               url: "{controller}/{action}",
               defaults: new { controller = "User", action = "OperationRegistration" }
           );
          //  routes.MapRoute(
          //    name: "Index",
          //    url: "{controller}/{action}/{id}",
          //    defaults: new { controller = "User", action = "OperationRegistration", id = UrlParameter.Optional }
          //);
        }
    }
}

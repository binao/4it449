using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeWork9
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            // Map LogIn route to sessions controllers create action
            routes.MapRoute(
               "LogIn", // Route name
               "LogIn", // URL with parameters
               new { controller = "Sessions", action = "Create" } // Parameter defaults
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Orders", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

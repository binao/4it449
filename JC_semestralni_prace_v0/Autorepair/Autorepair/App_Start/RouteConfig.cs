using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Autorepair
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.RouteExistingFiles = false;

            routes.LowercaseUrls = true;
            //SVG picture route for HP
            routes.MapRoute(
                name: "SVG1",
                url: "Pictures/{file}.svg",
                defaults: new { controller = "Home", action = "Picture", file = UrlParameter.Optional}
            );

            //SVG picture route for other pages
            routes.MapRoute(
                name: "SVG2",
                url: "{controller}/Pictures/{file}.svg",
                defaults: new { controller = "Home", action = "Picture", file = UrlParameter.Optional}
            );

            //Unevrsal route for basic contents
            routes.MapRoute(
                name: "ContentMenu",
                url: "Home/{contentPage}",
                defaults: new { controller = "Home", action = "ContentMenu" },
                constraints: new { contentPage = PageContent.PageContentRoute }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}

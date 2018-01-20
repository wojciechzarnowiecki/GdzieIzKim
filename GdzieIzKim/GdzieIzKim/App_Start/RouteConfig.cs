using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GdzieIzKim
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Admin",
                url: "admin/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "AdminKat",
                url: "Home/Kat/{action}/{id}",
                defaults: new { controller = "Kat", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminLoc",
                url: "Home/Lok/{action}/{id}",
                defaults: new { controller = "LoK", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Mapa",
                url: "Home/Home/Mapa",
                defaults: new { controller = "Home", action = "Mapa", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}

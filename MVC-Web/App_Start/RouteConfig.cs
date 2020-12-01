using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{idConsorcio}/{idUnidad}",
                defaults: new { controller = "Home", action = "Inicio", idConsorcio = UrlParameter.Optional, idUnidad = UrlParameter.Optional }
            );
        }
    }
}

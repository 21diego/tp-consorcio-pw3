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
<<<<<<< HEAD
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Inicio", id = UrlParameter.Optional }
=======
                url: "{controller}/{action}/{id}/{IdUnidad}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, IdUnidad = UrlParameter.Optional }
>>>>>>> remotes/origin/expensa2
            );
        }
    }
}

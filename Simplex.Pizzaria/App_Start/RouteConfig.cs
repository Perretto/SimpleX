using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Simplex.Pizzaria
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{Areas}/{controller}/{action}/{id}",
                defaults: new { Areas=UrlParameter.Optional,  controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

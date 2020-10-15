using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Login_MVC_
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            ///!!!!!!!!! Падазрительная вещьььь
             routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Ignore unwanted routes first
            routes.IgnoreRoute("{area}/Default");
            routes.IgnoreRoute("{area}/Default/Index");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

        }
    }
}

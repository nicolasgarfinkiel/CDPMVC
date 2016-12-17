using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CDP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Chofer",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "ChoferController", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Chofer", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapPageRoute("DefaultPage", "", "~/Views/Chofer.aspx"); 
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
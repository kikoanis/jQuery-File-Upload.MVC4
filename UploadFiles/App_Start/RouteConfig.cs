using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UploadFiles
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // configure HttpHandler for serving static images
            HttpMethodConstraint GetFileMethodConstraints = new HttpMethodConstraint(new string[]{ "GET" });
            Route GetFileRoute = new Route(
                url: "Files/{id}/{filename}",
                routeHandler: new DobImageRouteHandler(),
                defaults: null,
                constraints: new RouteValueDictionary { { "httpMethod", GetFileMethodConstraints } }
            );
            routes.Add("GetFileRoute", GetFileRoute);


            //routes.MapRoute(
            //    name: "Get File",
            //    url: "Files/{id}/{filename}",
            //    defaults: new { controller = "Files", action = "Find" },
            //    constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            //);

            routes.MapRoute(
                name: "Delete File",
                url: "Files/{id}/{filename}",
                defaults: new { controller = "Files", action = "Delete" },
                constraints: new { httpMethod = new HttpMethodConstraint("DELETE") }
            );

            routes.MapRoute(
                name: "Get Json File List",
                url: "Files",
                defaults: new { controller = "Files", action = "List" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );

            routes.MapRoute(
                name: "Post Files",
                url: "Files",
                defaults: new { controller = "Files", action = "Uploads" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

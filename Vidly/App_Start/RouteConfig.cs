using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            // Order of routes.MapRoute matters for the most specific to the most general, 
            // in this case Default is the most general of the routes
            //routes.MapRoute(
            //    name: "MoviesByReleaseDate",
            //    url: "{movies}/{released}/{year}/{month}",
            //    defaults: new { controller = "Movies", action = "ByReleaseDate" },
            //    constraints: new { year = @"\d{4}", month = @"\d{2}" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
using System.Web.Routing;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Fanex.EmbeddedResource.AppStart), "Start")]
namespace Fanex.EmbeddedResource
{
    internal class AppStart
    {
        public static void Start()
        {
            ConfigureRoutes();
        }

        private static void ConfigureRoutes()
        {
            RouteTable.Routes.Add(new Route(EmbeddedConfig.Path + "{*path}", new RouteValueDictionary(new { }), new RouteValueDictionary(new { }), new EmbeddedResourceRouteHandler()));
        }
    }
}

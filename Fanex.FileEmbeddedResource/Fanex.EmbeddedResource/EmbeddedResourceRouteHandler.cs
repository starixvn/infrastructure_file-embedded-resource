namespace Fanex.EmbeddedResource
{
    using System.Web;
    using System.Web.Routing;

    public class EmbeddedResourceRouteHandler : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return new EmbeddedResourceHttpHandler(requestContext.RouteData);
        }
    }
}

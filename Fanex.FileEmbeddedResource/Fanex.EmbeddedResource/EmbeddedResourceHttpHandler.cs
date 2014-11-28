namespace Fanex.EmbeddedResource
{
    using System.Web;
    using System.Web.Routing;

    public class EmbeddedResourceHttpHandler : IHttpHandler
    {
        private RouteData _routeData;
        public EmbeddedResourceHttpHandler(RouteData routeData)
        {
            _routeData = routeData;
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var routeDataValues = _routeData.Values;
            var path = routeDataValues["path"].ToString();

            string tempVirtualPath = path.Replace(EmbeddedConfig.EmbeddedPath, string.Empty);
            var fileExtension = tempVirtualPath.Replace("/", ".");

            string nameSpace = EmbeddedConfig.CurrentAssembly.GetName().Name;
            string manifestResourceName = string.Format("{0}.{1}", nameSpace, fileExtension);
            var stream = EmbeddedConfig.CurrentAssembly.GetManifestResourceStream(manifestResourceName);
            context.Response.Clear();
            context.Response.ContentType = MimeMapping.GetMimeMapping(path);
            stream.CopyTo(context.Response.OutputStream);
        }
    }
}

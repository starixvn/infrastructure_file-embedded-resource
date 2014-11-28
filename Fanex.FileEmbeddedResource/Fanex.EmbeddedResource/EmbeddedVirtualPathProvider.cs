namespace Fanex.EmbeddedResource
{
    using System;
    using System.Collections;
    using System.Web.Caching;
    using System.Web.Hosting;

    public class EmbeddedVirtualPathProvider : VirtualPathProvider
    {
        private VirtualPathProvider _previous;

        public EmbeddedVirtualPathProvider(VirtualPathProvider previous)
        {
            _previous = previous;
        }

        public override bool FileExists(string virtualPath)
        {
            if (IsEmbeddedPath(virtualPath))
            {
                return true;
            }
            else
            {
                return _previous.FileExists(virtualPath);
            }
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (IsEmbeddedPath(virtualPath))
            {
                return null;
            }
            else
            {
                return _previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
            }
        }

        public override VirtualDirectory GetDirectory(string virtualDir)
        {
            return _previous.GetDirectory(virtualDir);
        }

        public override bool DirectoryExists(string virtualDir)
        {
            return _previous.DirectoryExists(virtualDir);
        }
        public override VirtualFile GetFile(string virtualPath)
        {
            if (IsEmbeddedPath(virtualPath))
            {
                string tempVirtualPath = virtualPath.Replace(EmbeddedConfig.EmbeddedPath, string.Empty);
                string fileNameWithExtension = tempVirtualPath.Replace("/", ".");

                string nameSpace = EmbeddedConfig.CurrentAssembly.GetName().Name;
                string manifestResourceName = string.Format("{0}.{1}", nameSpace, fileNameWithExtension);
                var stream = EmbeddedConfig.CurrentAssembly.GetManifestResourceStream(manifestResourceName);
                return new EmbeddedVirtualFile(virtualPath, stream);
            }
            else
            {
                return _previous.GetFile(virtualPath);
            }
        }

        private bool IsEmbeddedPath(string path)
        {
            return path.Contains(EmbeddedConfig.EmbeddedPath);
        }
    }
}

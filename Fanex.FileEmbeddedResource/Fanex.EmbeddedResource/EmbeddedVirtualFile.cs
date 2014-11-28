namespace Fanex.EmbeddedResource
{
    using System.IO;
    using System.Web.Hosting;

    public class EmbeddedVirtualFile : VirtualFile
    {
        private Stream _stream;

        public EmbeddedVirtualFile(string virtualPath, Stream stream)
            : base(virtualPath)
        {
            _stream = stream;
        }

        public override Stream Open()
        {
            return _stream;
        }
    }
}

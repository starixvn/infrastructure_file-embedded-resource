namespace Fanex.EmbeddedResource
{
    using System.Reflection;

    public static class EmbeddedConfig
    {
        public const string Path = "Resource/EmbeddedFile/";

        public static Assembly CurrentAssembly { get; set; }

        internal static string EmbeddedPath
        {
            get
            {
                return "~/" + Path;
            }
        }
    }
}

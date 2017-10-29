using X3.iOS.DependencyServices;
using X3._Shared.Common;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePathResolver))]

namespace X3.iOS.DependencyServices
{
    public class FilePathResolver : FilePathResolverBase
    {
        public override string GetToolbarItemIconPath(string iconFileName)
        {
            var path = Compose("{0}", iconFileName);
            return path;
        }
    }
}
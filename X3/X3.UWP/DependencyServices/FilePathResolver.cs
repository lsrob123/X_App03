using X3.UWP.DependencyServices;
using X3._Shared.Common;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePathResolver))]

namespace X3.UWP.DependencyServices
{
    public class FilePathResolver : FilePathResolverBase
    {
        public override string GetToolbarItemIconPath(string iconFileName)
        {
            return Compose("Assets/ToobarItemIcons/{0}", iconFileName);
        }
    }
}
using Xamarin.Forms;

namespace X3._Shared.Common
{
    public interface IDetailPageResolver
    {
        NavigationPage Resolve(string pageType);
    }
}
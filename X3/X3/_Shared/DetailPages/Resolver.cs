using System.Threading.Tasks;
using X3.Domains.Contacts;
using X3.Domains.Dashboard;
using Xamarin.Forms;

namespace X3._Shared.DetailPages
{
    public static class Resolver
    {
        public static NavigationPage Resolve(string pageType)
        {
            switch (pageType)
            {
                case Constants.Dashboard:
                    return CreateDetailPage(new Dashboard());
                case Constants.Contacts:
                    return CreateDetailPage(new Contacts());
                default:
                    return null;
            }
        }

        private static NavigationPage CreateDetailPage(Page detailPage)
        {
            detailPage.ToolbarItems.Add(new ToolbarItem("Filter", null, async () => await Task.Run(() =>
            {
                var a = 1;
            })));
            return new NavigationPage(detailPage) {BarBackgroundColor = Color.OrangeRed, BarTextColor = Color.White};
        }
    }
}
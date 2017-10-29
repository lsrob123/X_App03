using System.Collections.Generic;
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
            var toobarItems = new List<ToolbarItem>
            {
                new ToolbarItem("Filter", null, async () => await Task.Run(() =>
                    {
                        var a = 1;
                    }
                )),
                new ToolbarItem("Option", null, async () => await Task.Run(() =>
                    {
                        var a = 1;
                    }
                ))
            };

            foreach (var toolbarItem in toobarItems)
                detailPage.ToolbarItems.Add(toolbarItem);
            return new NavigationPage(detailPage) {BarBackgroundColor = Color.OrangeRed, BarTextColor = Color.White};
        }
    }
}
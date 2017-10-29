using System.Collections.Generic;
using System.Threading.Tasks;
using X3.Domains.Contacts;
using X3.Domains.Dashboard;
using X3._Shared.Common;
using Xamarin.Forms;

[assembly: Dependency(typeof(DetailPageResolver))]

namespace X3._Shared.Common
{
    public class DetailPageResolver : IDetailPageResolver
    {
        private IFilePathResolver FilePathResolver => DependencyService.Get<IFilePathResolver>();

        public NavigationPage Resolve(string pageType)
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

        private NavigationPage CreateDetailPage(Page detailPage)
        {
            var toobarItems = new List<ToolbarItem>
            {
                new ToolbarItem("Settings", FilePathResolver.GetToolbarItemIconPath("file19.png"),
                    async () => await Task.Run(() =>
                        {
                            var a = 1;
                        }
                    )),
                new ToolbarItem("Account", FilePathResolver.GetToolbarItemIconPath("file01.png"),
                async () => await Task.Run(() =>
                    {
                        var a = 1;
                    }
                ),ToolbarItemOrder.Secondary),
                new ToolbarItem("Other", FilePathResolver.GetToolbarItemIconPath("file19.png"),
                    async () => await Task.Run(() =>
                        {
                            var a = 1;
                        }
                    ),ToolbarItemOrder.Secondary),
            };

            foreach (var toolbarItem in toobarItems)
                detailPage.ToolbarItems.Add(toolbarItem);
            return new NavigationPage(detailPage) {BarBackgroundColor = Color.OrangeRed, BarTextColor = Color.White};
        }
    }
}
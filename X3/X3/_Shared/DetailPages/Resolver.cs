using X3.Domains.Contacts;
using X3.Domains.Dashboard;
using Xamarin.Forms;

namespace X3._Shared.DetailPages
{
    public static class Resolver
    {
        public static readonly NavigationPage Dashboard = new NavigationPage(new Dashboard());
        public static readonly NavigationPage Contacts = new NavigationPage(new Contacts());

        public static NavigationPage Resolve(string pageType)
        {
            switch (pageType)
            {
                case Constants.Dashboard:
                    return new NavigationPage(new Dashboard());
                case Constants.Contacts:
                    return new NavigationPage(new Contacts());
                //case Constants.Dashboard:
                //    return Dashboard;
                //case Constants.Contacts:
                //    return Contacts;
                default:
                    break;
            }

            return null;
        }
    }
}
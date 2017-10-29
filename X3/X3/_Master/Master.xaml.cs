using System;
using X3._Shared.Common;
using X3._Shared.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X3._Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void BtnDashboard_OnClicked(object sender, EventArgs e)
        {
            OpenDetailPage(Constants.Dashboard);
        }

        private void BtnContacts_OnClicked(object sender, EventArgs e)
        {
            OpenDetailPage(Constants.Contacts);
        }

        private void OpenDetailPage(string detailPage)
        {
            Title = $"X3 - {detailPage}";
            MessagingCenter.Send(this, nameof(OpenDetailPageMessage), new OpenDetailPageMessage(detailPage));
        }
    }
}
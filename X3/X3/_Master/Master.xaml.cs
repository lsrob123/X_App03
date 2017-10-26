using System;
using Lx.X.Utilities.Mediator;
using X3._Shared.DetailPages;
using X3._Shared.MediatorMessages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X3._Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        private readonly IMediator _mediator;

        public Master()
        {
            _mediator = Mediator.Default;
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
            _mediator.Publish(new OpenDetailPageMessage(detailPage));

        }
    }
}
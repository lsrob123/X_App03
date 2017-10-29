using X3._Shared.Common;
using X3._Shared.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X3._Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        private readonly IDetailPageResolver _detailPageResolver = DependencyService.Get<IDetailPageResolver>();

        public MasterDetail()
        {
            InitializeComponent();
            Detail = _detailPageResolver.Resolve(Constants.Dashboard);

            MessagingCenter.Subscribe<Master, OpenDetailPageMessage>(this, nameof(OpenDetailPageMessage),
                (sender, message) => Handle(message));
        }

        public void Handle(OpenDetailPageMessage message)
        {
            Detail = _detailPageResolver.Resolve(message.Data);

            if (!MasterBehavior.Equals(MasterBehavior.Split) &&
                !MasterBehavior.Equals(MasterBehavior.SplitOnLandscape) &&
                !MasterBehavior.Equals(MasterBehavior.SplitOnPortrait))
                IsPresented = false;
        }
    }
}
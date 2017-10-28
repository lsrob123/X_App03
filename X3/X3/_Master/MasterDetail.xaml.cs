using X3._Shared.DetailPages;
using X3._Shared.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X3._Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            Detail = Resolver.Resolve(Constants.Dashboard);

            MessagingCenter.Subscribe<Master, OpenDetailPageMessage>(this, nameof(OpenDetailPageMessage),
                (sender, message) => Handle(message));
        }

        public void Handle(OpenDetailPageMessage message)
        {
            Detail = Resolver.Resolve(message.Data);

            if (!MasterBehavior.Equals(MasterBehavior.Split) &&
                !MasterBehavior.Equals(MasterBehavior.SplitOnLandscape) &&
                !MasterBehavior.Equals(MasterBehavior.SplitOnPortrait))
                IsPresented = false;
        }
    }
}
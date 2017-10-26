using Lx.X.Utilities.Mediator;
using X3._Shared.DetailPages;
using X3._Shared.MediatorMessages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X3._Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage, IMediatorMessageHandler<OpenDetailPageMessage>
    {
        public MasterDetail()
        {
            InitializeComponent();
            Mediator.Default.Subscribe(this);
            Detail = Resolver.Resolve(Constants.Dashboard);
        }

        public void Handle(OpenDetailPageMessage message)
        {
            Detail = Resolver.Resolve(message.DetailPage);
            IsPresented = false;
        }
    }
}
using Lx.X.Utilities.Infrastructure;

namespace X3._Shared.Messaging
{
    public class OpenDetailPageMessage : MessageBase<string>
    {
        public OpenDetailPageMessage(string detailPage) : base(detailPage)
        {
        }
    }
}
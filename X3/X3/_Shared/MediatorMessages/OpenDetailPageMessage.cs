using Lx.X.Utilities.Infrastructure;

namespace X3._Shared.MediatorMessages
{
    public class OpenDetailPageMessage : IMessageBase
    {
        public OpenDetailPageMessage(string detailPage)
        {
            DetailPage = detailPage;
        }

        public string DetailPage { get; protected set; }
    }
}
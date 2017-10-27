namespace Lx.X.Utilities.Infrastructure
{
    public abstract class MessageBase<TData> : IMessageBase<TData>
    {
        protected MessageBase(TData message)
        {
            Data = message;
        }

        public TData Data { get; protected set; }
    }
}
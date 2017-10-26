using Lx.X.Utilities.Infrastructure;

namespace Lx.X.Utilities.Mediator
{
    public interface IMediatorMessageHandler
    {
    }

    public interface IMediatorMessageHandler<in T> : IMediatorMessageHandler
        where T : IMessageBase
    {
        void Handle(T message);
    }
}
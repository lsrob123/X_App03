using System.Threading.Tasks;
using Lx.X.Utilities.Infrastructure;

namespace Lx.X.Utilities.Mediator
{
    public interface IMediator
    {
        IMediator Publish<TMessage>(TMessage message) where TMessage : IMessageBase;

        Task<IMediator> PublishAsync<TMessage>(TMessage message) where TMessage : IMessageBase;

        IMediator Subscribe<TMessage>(IMediatorMessageHandler<TMessage> handler) where TMessage : IMessageBase;
    }
}
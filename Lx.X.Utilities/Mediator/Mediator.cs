using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lx.X.Utilities.Infrastructure;

namespace Lx.X.Utilities.Mediator
{
    public class Mediator : IMediator
    {
        protected static IMediator DefaultInstance;

        protected static readonly Dictionary<Type, List<IMediatorMessageHandler>> Handlers =
            new Dictionary<Type, List<IMediatorMessageHandler>>();

        protected static readonly ReaderWriterLockSlim Lock =
            new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        protected static readonly Type MediatorType = typeof(Mediator);
        protected static readonly Type MediatorMessageHandlerType = typeof(IMediatorMessageHandler);

        static Mediator()
        {
            DefaultInstance = new Mediator();
        }

        public static IMediator Default => DefaultInstance;

        public async Task<IMediator> PublishAsync<T>(T message)
            where T : IMessageBase
        {
            return await Task.Run(() => Publish(message));
        }

        public virtual IMediator Publish<T>(T message)
            where T : IMessageBase
        {
            var eventType = message.GetType();
            List<IMediatorMessageHandler> handlers;
            Lock.EnterReadLock();
            try
            {
                Handlers.TryGetValue(eventType, out handlers);
            }
            finally
            {
                Lock.ExitReadLock();
            }

            if (handlers != null)
                Parallel.ForEach(handlers, handler => ExecuteHandler(handler, message));
            return this;
        }

        public virtual IMediator Subscribe<T>(IMediatorMessageHandler<T> handler)
            where T : IMessageBase
        {
            var eventType = typeof(T);

            Lock.EnterUpgradeableReadLock();
            try
            {
                if (!Handlers.TryGetValue(eventType, out List<IMediatorMessageHandler> handlers))
                {
                    Lock.EnterWriteLock();
                    try
                    {
                        Handlers.Add(eventType, new List<IMediatorMessageHandler> {handler});
                    }
                    finally
                    {
                        Lock.ExitWriteLock();
                    }
                }
                else if (handlers.All(x => x != handler))
                {
                    Lock.EnterWriteLock();
                    try
                    {
                        handlers.Add(handler);
                    }
                    finally
                    {
                        Lock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                Lock.EnterUpgradeableReadLock();
            }

            return this;
        }

        /// <summary>
        ///     Self starter
        /// </summary>
        public static void Start()
        {
        }

        protected void ExecuteHandler<T>(IMediatorMessageHandler handler, T message) where T : IMessageBase
        {
            if (handler == null || message == null)
                return; //TODO: Add logging logic

            try
            {
                ((IMediatorMessageHandler<T>) handler)?.Handle(message);
            }
            catch (Exception ex)
            {
                //TODO: Add logging logic
#if DEBUG
                var a = ex;
#endif
            }
        }

        protected void RegisterHandler<TMessage>(object o)
            where TMessage : IMessageBase
        {
            Subscribe(o as IMediatorMessageHandler<TMessage>);
        }
    }
}
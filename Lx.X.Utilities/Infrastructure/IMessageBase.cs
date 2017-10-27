namespace Lx.X.Utilities.Infrastructure
{
    public interface IMessageBase
    {
    }

    public interface IMessageBase<out TData> : IMessageBase
    {
        TData Data { get; }
    }
}
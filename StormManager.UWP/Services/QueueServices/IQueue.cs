using StormManager.UWP.Common;

namespace StormManager.UWP.Services.QueueServices
{
    public interface IQueue<T>
    {
        #region Events
        event TypedEventHandler<T> Enqueued;
        event TypedEventHandler<T> Dequeued;
        #endregion
        void Enqueue(T item);
        T Dequeue();
    }
}

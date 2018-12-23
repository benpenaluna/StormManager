using StormManager.UWP.Common;

namespace StormManager.UWP.Services.QueueServices
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/QueueServices/IQueue.cs

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

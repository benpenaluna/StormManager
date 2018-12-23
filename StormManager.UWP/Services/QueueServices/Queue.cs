using StormManager.UWP.Common;

namespace StormManager.UWP.Services.QueueServices
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/QueueServices/Queue.cs

    public class Queue<T> : IQueue<T>
    {
        public static Queue<T> Instance { get; } =
            new Queue<T>();

        private Queue()
        {

        }

        System.Collections.Generic.Queue<T> queue =
            new System.Collections.Generic.Queue<T>();

        public event TypedEventHandler<T> Enqueued;

        public void Enqueue(T item)
        {
            queue.Enqueue(item);
            Enqueued?.Invoke(null, item);
        }

        public event TypedEventHandler<T> Dequeued;

        public T Dequeue()
        {
            T item = queue.Dequeue();
            Dequeued?.Invoke(null, item);
            return item;
        }
    }
}

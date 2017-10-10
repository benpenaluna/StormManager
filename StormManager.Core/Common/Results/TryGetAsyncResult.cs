namespace StormManager.Core.Common.Results
{
    public class TryGetAsyncResult<T> : ITryGetAsyncResult<T>
    {
        public bool Success { get; }
        public T Result { get; }

        public TryGetAsyncResult(bool success, T result)
        {
            this.Success = success;
            this.Result = result;
        }
    }
}

namespace StormManager.Core.Common.Results
{
    public interface ITryGetAsyncResult<T>
    {
        bool Success { get; }
        T Result { get; }
    }
}

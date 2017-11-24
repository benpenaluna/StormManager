namespace StormManager.Core.Common.Results
{
    public interface ITryGetAsyncResult<out T>
    {
        bool Success { get; }
        T Result { get; }
    }
}

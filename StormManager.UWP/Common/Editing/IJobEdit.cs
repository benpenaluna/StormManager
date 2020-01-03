using StormManager.UWP.Models;

namespace StormManager.UWP.Common.Editing
{
    public interface IJobEdit
    {
        JobType JobType { get; set; }
        CompletionState CompletionState { get; set; }
    }
}

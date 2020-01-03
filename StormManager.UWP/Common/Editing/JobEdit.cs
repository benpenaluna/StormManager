using StormManager.UWP.Models;

namespace StormManager.UWP.Common.Editing
{
    public class JobEdit : IJobEdit
    {
        public JobType JobType { get; set; }
        public CompletionState CompletionState { get; set; }

        public JobEdit(JobType jobType, CompletionState completionState)
        {
            JobType = jobType;
            CompletionState = completionState;
        }
    }
}

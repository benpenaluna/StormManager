using System.Collections.Generic;
using System.Linq;
using StormManager.UWP.Persistence.Repositories;

namespace StormManager.UWP.Persistence.ObjectFramework
{
    internal static class RepoChanges
    {
        public static Queue<StateChange> Changes { get; internal set; }

        internal static bool QueueContains(object entity)
        {
            return RepoChanges.Changes.Any(change => change.Item == entity);
        }
    }
}

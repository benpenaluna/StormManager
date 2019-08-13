using System.Collections.Generic;

namespace StormManager.UWP.Persistence.Repositories
{
    public class RepoSet<TEntity> : List<TEntity> where TEntity : class
    {
        internal RepoSet()
        {
        }

        internal RepoSet(IEnumerable<TEntity> collection) : base(collection)
        {
        }
    }
}

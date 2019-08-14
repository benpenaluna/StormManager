namespace StormManager.UWP.Persistence.Repositories
{
    internal struct RepoChange<TEntity> where TEntity : class
    {
        public TEntity Item { get; set; }
        public DataManipulation DataManipulation { get; set; }

        public RepoChange(TEntity item, DataManipulation dataManipulation)
        {
            Item = item;
            DataManipulation = dataManipulation;
        } 
    }
}

namespace StormManager.UWP.Persistence.Repositories
{
    public struct StateChange
    {
        public object Item { get; set; }
        public DataManipulation DataManipulation { get; set; }

        internal StateChange(object item, DataManipulation dataManipulation)
        {
            Item = item;
            DataManipulation = dataManipulation;
        } 
    }
}

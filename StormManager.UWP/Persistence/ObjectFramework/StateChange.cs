using StormManager.UWP.Persistence.Repositories;

namespace StormManager.UWP.Persistence.ObjectFramework
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

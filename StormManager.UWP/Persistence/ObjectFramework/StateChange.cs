using StormManager.UWP.Common.SqlTransactions;

namespace StormManager.UWP.Persistence.ObjectFramework
{
    public struct StateChange
    {
        public object Item { get; set; }
        public SqlTransactionType DataManipulation { get; set; }

        internal StateChange(object item, SqlTransactionType sqlTransactionType)
        {
            Item = item;
            DataManipulation = sqlTransactionType;
        }
    }
}

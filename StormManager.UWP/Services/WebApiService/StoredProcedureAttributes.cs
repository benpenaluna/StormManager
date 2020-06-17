using StormManager.UWP.Common.SqlTransactions;

namespace StormManager.UWP.Services.WebApiService
{
    public struct StoredProcedureAttributes
    {
        public string StoredProcedureName { get; set; }

        public SqlTransactionType TransactionType { get; set; }

        internal StoredProcedureAttributes(string storedProcedureName, SqlTransactionType transactionType)
        {
            StoredProcedureName = storedProcedureName;
            TransactionType = transactionType;
        }
    }
}

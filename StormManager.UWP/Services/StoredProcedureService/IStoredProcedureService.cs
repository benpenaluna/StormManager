using System;
using StormManager.UWP.Common.SqlTransactions;

namespace StormManager.UWP.Services.StoredProcedureService
{
    public interface IStoredProcedureService
    {
        string GetStoredProcedureName(Type entity, SqlTransactionType sqlTransactionType);
    }
}

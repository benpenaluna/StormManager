using StormManager.UWP.Common.SqlTransactions;
using System;

namespace StormManager.UWP.Services.StoredProcedureService
{
    public interface IStoredProcedureService
    {
        string GetStoredProcedureName(Type entity, SqlTransactionType sqlTransactionType);
    }
}

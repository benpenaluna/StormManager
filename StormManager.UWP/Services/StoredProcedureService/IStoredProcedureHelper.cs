using StormManager.UWP.Common.SqlTransactions;
using System;

namespace StormManager.UWP.Services.StoredProcedureService
{
    public interface IStoredProcedureHelper
    {
        string GetStoredProcedureName(Type entity, SqlTransactionType sqlTransactionType);
    }
}

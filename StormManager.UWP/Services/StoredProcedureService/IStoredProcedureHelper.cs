﻿using System;
using StormManager.UWP.Common.SqlTransactions;

namespace StormManager.UWP.Services.StoredProcedureService
{
    public interface IStoredProcedureHelper
    {
        string GetStoredProcedureName(Type entity, SqlTransactionType sqlTransactionType);
    }
}

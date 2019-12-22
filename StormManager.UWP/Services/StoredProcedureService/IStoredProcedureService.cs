using System;
using StormManager.UWP.Persistence.ObjectFramework;

namespace StormManager.UWP.Services.StoredProcedureService
{
    public interface IStoredProcedureService
    {
        string GetStoredProcedureName(Type entity, DataManipulation dataManipulationType);
    }
}

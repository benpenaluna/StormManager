using System;
using System.Collections.Generic;
using StormManager.Standard.Models.InformationSchema;
using StormManager.UWP.Persistence.ObjectFramework;

namespace StormManager.UWP.Services.StoredProcedureService
{
    public interface IStoredProcedureHelper
    {
        string GetStoredProcedureName(Type entity, DataManipulation dataManipulationType);
    }
}

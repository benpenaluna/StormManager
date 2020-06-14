using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StormManager.UWP.Models;
using StormManager.UWP.Services.ResourceLoaderService;

namespace StormManager.UWP.Persistence.SqlParameters
{
    internal static class SqlStorageParameters
    {
        internal static SqlParameter[] GetSqlParameters<T>(this T payload)
        {
            if (payload.GetType() == typeof(JobType))
                return GetJobTypeSqlParameters(payload as JobType);

            var message = ResourceLoaderService.GetResourceValue("SqlStorageParameters.ArgumentException");
            throw new ArgumentException(string.Format(message, typeof(T)));
        }

        private static SqlParameter[] GetJobTypeSqlParameters_Add(JobType payload)
        {
            return GetJobTypeSqlParameters(payload);
        }
        
        private static SqlParameter[] GetJobTypeSqlParameters(JobType payload)
        {
            // TODO: find a way to remove literal strings here. If this changes in the future then we don't want to be updating this class
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter("@category", SqlDbType.NVarChar) {Value = payload.Category},
                new SqlParameter("@subCategory", SqlDbType.NVarChar) {Value = payload.SubCategory},
                new SqlParameter("@isUsed", SqlDbType.Bit) {Value = payload.IsUsed},
                new SqlParameter("@newJobArgb", SqlDbType.Int) {Value = payload.NewJobArgb},
                new SqlParameter("@agingJobArgb", SqlDbType.Int) {Value = payload.AgingJobArgb},
                new SqlParameter("@dateUpdated", SqlDbType.DateTime) {Value = payload.DateUpdated},
                new SqlParameter("@updatedBy", SqlDbType.NVarChar) {Value = payload.UpdatedBy}
            };

            if (payload.Id >= 0)
                parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = payload.Id });

            return parameters.ToArray();
        }
    }
}

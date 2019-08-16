using System;
using System.Data;
using System.Data.SqlClient;
using StormManager.UWP.Models;

namespace StormManager.UWP.Persistence.SqlParameters
{
    internal static class SqlStorageParameters
    {
        internal static SqlParameter[] GetSqlParameters<T>(this T payload)
        {
            if (payload.GetType() == typeof(JobType))
                return GetJobTypeSqlParameters(payload as JobType);

            throw new ArgumentException($"{typeof(T)} is not a recognised type.");
        }

        private static SqlParameter[] GetJobTypeSqlParameters(JobType payload)
        {
            // TODO: find a way to remove literal strings here. If this changes in the future then we don't want to be updating this class
            return new[]
            {
                new SqlParameter("@id", SqlDbType.Int) {Value = payload.Id},
                new SqlParameter("@category", SqlDbType.NVarChar) {Value = payload.Category},
                new SqlParameter("@subCategory", SqlDbType.NVarChar) {Value = payload.SubCategory},
                new SqlParameter("@isUsed", SqlDbType.Bit) {Value = payload.IsUsed},
                new SqlParameter("@newJobArgb", SqlDbType.Int) {Value = payload.NewJobArgb},
                new SqlParameter("@agingJobArgb", SqlDbType.Int) {Value = payload.AgingJobArgb}
            };
        }
    }
}

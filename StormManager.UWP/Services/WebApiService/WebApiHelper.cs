using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Autofac;
using Newtonsoft.Json;
using StormManager.UWP.Common.Exceptions;
using StormManager.UWP.Persistence.SqlParameters;
using StormManager.UWP.Services.NetworkAvailableService;

namespace StormManager.UWP.Services.WebApiService
{
    public class WebApiHelper : IWebApiHelper
    {
        private string ConnectionString { get; }

        public WebApiHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }
        
        public async Task<IEnumerable<T>> GetAsync<T>(string storedProcedureName)
        {
            if (await InternetConnectionExistsAsync() == false)
                throw new InternetConnectionUnavailableException();

            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();

                    if (conn.State == ConnectionState.Open)
                    {
                        const string jsonOutputParam = "@jsonOutput";
                        using (var cmd = new SqlCommand(storedProcedureName, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add(jsonOutputParam, SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;

                            await cmd.ExecuteNonQueryAsync();

                            var json = cmd.Parameters[jsonOutputParam].Value.ToString();
                            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }

            return null;
        }

        public async Task PutAsync<T>(string storedProcedureName, T payload)
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();

                    if (conn.State == ConnectionState.Open)
                    {
                        using (var cmd = new SqlCommand(storedProcedureName, conn))
                        {
                            cmd.Parameters.AddRange(payload.GetSqlParameters());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (ArgumentException e)
            {
                Debug.WriteLine("Exception: " + e.Message);
                throw;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
                throw;
            }
        }

        private static async Task<bool> InternetConnectionExistsAsync()
        {
            var networkAvailableService = App.Container.Resolve<INetworkAvailableService>();
            return await networkAvailableService.IsInternetAvailable();
        }
    }
}

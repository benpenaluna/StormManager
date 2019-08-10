using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StormManager.UWP.Models;

namespace StormManager.UWP.Services.WebApiService
{
    public partial class WebApiService : IWebApiService
    {
        private static readonly string ConnectionSting = "Server=tcp:stormmanagerserver.database.windows.net,1433;Initial Catalog=StormManager;Persist Security Info=False;User ID={0};Password={1};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;App=EntityFramework";
        
        public async Task<IEnumerable<T>> GetAsync<T>(string storedProcedureName)
        {
            try
            {
                var connectionString = await GetConnectionStringAsync();
                using (var conn = new SqlConnection(connectionString))
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
            //using (HttpClient http = WrappedHttpClient())
            //{
            //    try
            //    {
            //        string data = JsonConvert.SerializeObject(payload);
            //        http.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            //        HttpResponseMessage response =
            //            await http.PutAsync(uri, new HttpStringContent(data, UnicodeEncoding.Utf8, "application/json"));
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}

            try
            {
                var connectionString = await GetConnectionStringAsync();
                using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    if (conn.State == ConnectionState.Open)
                    {
                        using (var cmd = new SqlCommand(storedProcedureName, conn))
                        {
                            if (payload.GetType() == typeof(JobType))
                            {
                                var test = payload as JobType;

                                cmd.Parameters.Add("@id", SqlDbType.Int).Value = test?.Id;
                                cmd.Parameters.Add("@category", SqlDbType.NVarChar).Value = ((Standard.Models.JobType) test)?.Category;
                                cmd.Parameters.Add("@subCategory", SqlDbType.NVarChar).Value = test?.SubCategory;
                                cmd.Parameters.Add("@isUsed", SqlDbType.Bit).Value = test?.IsUsed;
                                cmd.Parameters.Add("@newJobArgb", SqlDbType.Int).Value = test?.NewJobArgb;
                                cmd.Parameters.Add("@agingJobArgb", SqlDbType.Int).Value = test?.AgingJobArgb;
                            }
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.ExecuteNonQuery();

                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
        }

        public static async Task<string> GetConnectionStringAsync()
        {
            ServerKeyService.IServerKeyService service = await ServerKeyService.ServerKeyService.CreateAsync();
            return string.Format(ConnectionSting, service.UserId, service.Password);
        }
    }
}

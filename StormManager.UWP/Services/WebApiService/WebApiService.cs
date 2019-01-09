using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StormManager.UWP.Services.WebApiService
{
    public partial class WebApiService : IWebApiService
    { 
        public async Task<IEnumerable<T>> GetAsync<T>(string storedProcedureName)
        {
            try
            {
                using (var conn = new SqlConnection(App.ConnectionString))
                {
                    await conn.OpenAsync();

                    if (conn.State == ConnectionState.Open)
                    {
                        const string jsonOutputParam = "@jsonOutput";
                        using (var cmd = new SqlCommand(storedProcedureName, conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
        }
    }
}

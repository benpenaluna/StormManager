using System;
using System.IO;
using System.Threading.Tasks;

namespace StormManager.Standard.Services.MapKeyService
{
    public class MapKeyHelper
    {
        private readonly string _keyFileLocation = @"C:\Users\Ben\Documents\Visual Studio 2015\Projects\StormManager\MapServicesKey.txt";

        public string Key { get; private set; }

        public async Task<MapKeyHelper> StartAsync()
        {
            Key  = await GetMapKeyAsync();
            return this;
        }

        private async Task<string> GetMapKeyAsync()
        {
            var key = string.Empty;
            try
            {
                using (var sr = new StreamReader(_keyFileLocation))
                {
                    key = await sr.ReadLineAsync();
                }
            }
            catch (FileNotFoundException)
            {
                return string.Empty;
            }

            return key;
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.MapKeyService
{
    public class MapKeyHelper
    {
        private readonly string _keyFileLocation = @"C:\Users\Ben\Documents\MapServicesKey.txt";

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
                using (var fs = new FileStream(_keyFileLocation, FileMode.Open))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        key = await sr.ReadLineAsync();
                    }
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

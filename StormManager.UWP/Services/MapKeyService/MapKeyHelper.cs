using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace StormManager.UWP.Services.MapKeyService
{
    public class MapKeyHelper
    {
        private readonly string _keyFileLocation = @"ms-appx:///Assets/key.txt";
        
        public string Key { get; private set; }

        public async Task<MapKeyHelper> CreateAsync()
        {
            Key = await GetMapKeyAsync();
            return this;
        }

        private async Task<string> GetMapKeyAsync()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(_keyFileLocation));
            var key = string.Empty;
            try
            {
                using (IRandomAccessStream stream = await file.OpenReadAsync())
                {
                    using (var dr = new DataReader(stream))
                    {
                        var length = (uint) stream.Size;
                        await dr.LoadAsync(length);
                        key = dr.ReadString(length);
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

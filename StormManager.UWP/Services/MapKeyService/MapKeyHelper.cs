using StormManager.UWP.Common.ExtensionMethods;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace StormManager.UWP.Services.MapKeyService
{
    public class MapKeyHelper : IMapKeyHelper
    {
        public string Key { get; private set; }

        private MapKeyHelper() { }

        public static Task<IMapKeyHelper> CreateAsync(string key = null)
        {
            var result = new MapKeyHelper();
            return result.InitialiseAsync(key);
        }

        private async Task<IMapKeyHelper> InitialiseAsync(string key = null)
        {
            if (key == null)
                key = await GetMapKeyAsync();

            Key = key.IsValidMapKey() ? key : string.Empty;

            return this;
        }

        private static async Task<string> GetMapKeyAsync()
        {
            var keyFileLocation = ResourceLoaderService.ResourceLoaderService.GetResourceValue("KeyFileLocation");
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(keyFileLocation));
            string key;

            try { key = await ReadKeyFromFile(file); }
            catch (FileNotFoundException) { return string.Empty; }

            return key;
        }

        private static async Task<string> ReadKeyFromFile(IRandomAccessStreamReference file)
        {
            string key;

            using (IRandomAccessStream stream = await file.OpenReadAsync())
            {
                using (var dr = new DataReader(stream))
                {
                    var length = (uint)stream.Size;
                    await dr.LoadAsync(length);
                    key = dr.ReadString(length);
                }
            }

            return key;
        }
    }
}

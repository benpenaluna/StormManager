using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace StormManager.UWP.Services.ServerKeyService
{
    public class ServerKeyHelper : IServerKeyHelper
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        private ServerKeyHelper() { }

        public static Task<IServerKeyHelper> CreateAsync(string secret = null)
        {
            var result = new ServerKeyHelper();
            return result.InitialiseAsync(secret);
        }

        private async Task<IServerKeyHelper> InitialiseAsync(string secret = null)
        {
            if (secret == null)
                secret = await GetServerKeyAsync();

            var secretSplits = secret.Split(new char[] { ',' }, StringSplitOptions.None);
            try
            {
                UserId = secretSplits[0];
                Password = secretSplits[1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return this;
        }

        private static async Task<string> GetServerKeyAsync()
        {
            var keyFileLocation = ResourceLoaderService.ResourceLoaderService.GetResourceValue("ServerKeyFileLocation");
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(keyFileLocation));
            string secret;

            try { secret = await ReadKeyFromFile(file); }
            catch (FileNotFoundException) { return string.Empty; }

            return secret;
        }

        private static async Task<string> ReadKeyFromFile(IRandomAccessStreamReference file)
        {
            string secret;

            using (IRandomAccessStream stream = await file.OpenReadAsync())
            {
                using (var dr = new DataReader(stream))
                {
                    var length = (uint)stream.Size;
                    await dr.LoadAsync(length);
                    secret = dr.ReadString(length);
                }
            }

            return secret;
        }
    }
}

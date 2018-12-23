namespace StormManager.UWP.Services.SerializationService
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/SerializationService/SerializationService.cs

    public static class SerializationService
    {
        private static ISerializationService _json;
        public static ISerializationService Json => _json ?? (_json = new JsonSerializationService());
    }
}

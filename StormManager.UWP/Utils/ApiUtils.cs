using Windows.Foundation.Metadata;

namespace StormManager.UWP.Utils
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Utils/ApiUtils.cs

    public static class ApiUtils
    {
        static bool? isHardwareButtonsApiPresent;
        public static bool IsHardwareButtonsApiPresent => isHardwareButtonsApiPresent ?? (isHardwareButtonsApiPresent = ApiInformation.IsTypePresent(@"Windows.Phone.UI.Input.HardwareButtons")).Value;
    }
}

using System;
using System.Threading.Tasks;
using Windows.Media.Capture;

namespace StormManager.UWP.Utils
{
    //Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Utils/AudioUtils.cs

    public static class AudioUtils
    {
        public async static Task<bool> RequestMicrophonePermission()
        {
            try
            {
                var settings = new MediaCaptureInitializationSettings
                {
                    StreamingCaptureMode = StreamingCaptureMode.Audio,
                    MediaCategory = MediaCategory.Speech,
                };
                var capture = new MediaCapture();
                await capture.InitializeAsync(settings);
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (Exception ex)
            {
                if (ex.HResult == -1072845856)
                {
                    // No Audio Capture devices are present on this system.
                }
                return false;
            }
            return true;
        }
    }
}

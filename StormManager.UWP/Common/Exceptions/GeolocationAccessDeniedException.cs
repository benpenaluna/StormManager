using System;

namespace StormManager.UWP.Common.Exceptions
{
    public class GeolocationAccessDeniedException : Exception
    {
        public GeolocationAccessDeniedException()
        {
        }

        public GeolocationAccessDeniedException(string message) : base(message)
        {
        }

        public GeolocationAccessDeniedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

using System;

namespace StormManager.UWP.Common.Exceptions
{
    public class InternetConnectionUnavailableException : Exception
    {
        public InternetConnectionUnavailableException()
        {
        }

        public InternetConnectionUnavailableException(string message) : base(message)
        {
        }

        public InternetConnectionUnavailableException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

using System;
using StormManager.UWP.Common.Exceptions;
using Xunit;

namespace StormManager.UWP.Tests.Common.Exceptions
{
    public class GeolocationAccessDeniedExceptionTests
    {
        private static string _message = "message";
        private static readonly Exception Ex = new Exception();

        #region Tests

        [Fact]
        public void GeolocationAccessDeniedException_Throw()
        {
            Assert.Throws<GeolocationAccessDeniedException>(() => Throw());
        }

        [Fact]
        public void GeolocationAccessDeniedException_ThrowWithMessage()
        {
            var ex = Assert.Throws<GeolocationAccessDeniedException>(() => ThrowWithMessage());
            Assert.Equal(_message, ex.Message);
        }

        [Fact]
        public void GeolocationAccessDeniedException_ThrowWithMessageInnerEx()
        {
            var ex = Assert.Throws<GeolocationAccessDeniedException>(() => ThrowWithMessageInnerEx());
            Assert.Equal(_message, ex.Message);
            Assert.Equal(Ex, ex.InnerException);
        }

        #endregion

        #region Helper_Methods

        private static void Throw()
        {
            throw new GeolocationAccessDeniedException();
        }

        private static void ThrowWithMessage()
        {
            throw new GeolocationAccessDeniedException(_message);
        }

        private static void ThrowWithMessageInnerEx()
        {
            throw new GeolocationAccessDeniedException(_message, Ex);
        }
        
        #endregion
    }
}

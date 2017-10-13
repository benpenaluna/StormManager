using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StormManager.UWP.Common.Exceptions;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace StormManager.UWP.Tests.Common.Exceptions
{
    [TestClass]
    public class GeolocationAccessDeniedExceptionTests
    {
        private string _message = "message";
        private readonly Exception _ex = new Exception(); 

        [Fact]
        public void GeolocationAccessDeniedException_Throw()
        {
            Xunit.Assert.Throws<GeolocationAccessDeniedException>(() => Throw());
        }

        [Fact]
        public void GeolocationAccessDeniedException_ThrowWithMessage()
        {
            var ex = Assert.ThrowsException<GeolocationAccessDeniedException>(() => ThrowWithMessage());
            Assert.AreEqual(_message, ex.Message);
        }

        [Fact]
        public void GeolocationAccessDeniedException_ThrowWithMessageInnerEx()
        {
            var ex = Assert.ThrowsException<GeolocationAccessDeniedException>(() => ThrowWithMessageInnerEx());
            Assert.AreEqual(_message, ex.Message);
            Assert.AreEqual(_ex, ex.InnerException);
        }

        private void Throw()
        {
            throw new GeolocationAccessDeniedException();
        }

        private void ThrowWithMessage()
        {
            throw new GeolocationAccessDeniedException(_message);
        }

        private void ThrowWithMessageInnerEx()
        {
            throw new GeolocationAccessDeniedException(_message, _ex);
        }
    }
}

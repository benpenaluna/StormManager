using System;
using Windows.Web.Http;

namespace StormManager.UWP.Services.WebApiService
{
    public partial class WebApiService
    {
        public class WebApiException : Exception
        {
            public HttpStatusCode Status { get; set; }
        }
    }
}
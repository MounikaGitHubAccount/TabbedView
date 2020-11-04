using System;
using System.Net.Http;
using Xamarin.Forms;

namespace TabbedView.Services
{
    public class HttpServiceClient : System.Net.Http.HttpClient
    {
        public HttpServiceClient()
        {

        }

        public HttpServiceClient(HttpMessageHandler handler) : base(handler)
        {

        }
    }
}
using System;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace xivapi
{
    public class XIVAPI
    {
        private const string XIVAPI_DEFAULT_HOST = "https://xivapi.com";
        private const string XIVAPI_DEFAULT_KEY = "";

        internal string hostname;
        internal string apiKey;

        internal HttpClient httpClient;

        public XIVAPI([Optional] string? host, [Optional] string? key)
        {
            if (Environment.GetEnvironmentVariable("XIVAPI_HOST") != null)
            {
                hostname = Environment.GetEnvironmentVariable("XIVAPI_HOST");
            }
            else if (!String.IsNullOrWhiteSpace(host))
            {
                hostname = host;
            }
            else
            {
                hostname = XIVAPI_DEFAULT_HOST;
            }

            if (Environment.GetEnvironmentVariable("XIVAPI_KEY") != null)
            {
                apiKey = Environment.GetEnvironmentVariable("XIVAPI_KEY");
            }
            else if (String.IsNullOrWhiteSpace(key))
            {
                apiKey = key;
            }
            else
            {
                apiKey = XIVAPI_DEFAULT_KEY;
            }

            httpClient = new HttpClient();
        }
    }
}

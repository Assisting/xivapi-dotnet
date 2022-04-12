using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using xivapi.Models;

namespace xivapi
{
    public class XIVAPI
    {
        private const string XIVAPI_DEFAULT_HOST = "https://xivapi.com";
        private const string XIVAPI_DEFAULT_KEY = "";

        private string hostname;
        private string apiKey;

        HttpClient httpClient;

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

        public async Task<PaginatedResult<FreeCompanySearchResult>> SearchFreeCompany(string searchKey, [Optional] ServerName? serverName, [Optional] int? page)
        {
            UriBuilder requestUri = new UriBuilder($"{hostname}/freecompany/search");
            var query = HttpUtility.ParseQueryString(requestUri.Query);

            // Non-optional
            if (String.IsNullOrWhiteSpace(searchKey))
            {
                throw new ArgumentException("Must supply a search key for free company.", paramName: "searchKey");
            }
            else
            {
                query["name"] = searchKey;
            }

            // Optional
            if (serverName != null)
            {
                query["server"] = serverName.Value;
            }
            if (page != null)
            {
                query["page"] = page.ToString();
            }
            if (!String.IsNullOrWhiteSpace(apiKey))
            {
                query["private_key"] = apiKey;
            }

            requestUri.Query = query.ToString();

            var response = await httpClient.GetAsync(requestUri.Uri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<PaginatedResult<FreeCompanySearchResult>>();
            }
            else
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new HttpRequestException($"Remote service returned not found at {response.RequestMessage.RequestUri}", null, HttpStatusCode.NotFound);
                    case HttpStatusCode.TooManyRequests:
                        throw new HttpRequestException($"Rate limited by remote service.", null, HttpStatusCode.TooManyRequests);
                    case HttpStatusCode.ServiceUnavailable:
                        throw new HttpRequestException($"Remote service under mainenance.", null, HttpStatusCode.ServiceUnavailable);
                    default:
                        throw new HttpRequestException($"Remote service returned non-success error code {response.StatusCode} with content {response.Content}", null, response.StatusCode);
                }
            }
        }

        public async Task<FreeCompanyGetResult> GetFreeCompany(FreeCompanySearchResult searchResult, [Optional] IList<string>? additionalData, [Optional] bool? includeMembers)
        {
            if (additionalData == null)
            {
                additionalData = new List<string>();
            }
            if (!additionalData.Contains("FCM") && includeMembers == true)
            {
                additionalData.Add("FCM");
            }
            return await GetFreeCompany(searchResult.ID, additionalData);
        }

        public async Task<FreeCompanyGetResult> GetFreeCompany(string ID, [Optional] IList<string>? additionalData, [Optional] bool? includeMembers)
        {
            if (additionalData == null)
            {
                additionalData = new List<string>();
            }
            if (!additionalData.Contains("FCM") && includeMembers == true)
            {
                additionalData.Add("FCM");
            }

            // Non-optional
            if (String.IsNullOrWhiteSpace(ID))
            {
                throw new ArgumentException("Must supply an ID to retrieve a free company.", paramName: "ID");
            }
            UriBuilder requestUri = new UriBuilder($"{hostname}/freecompany/{ID}");
            var query = HttpUtility.ParseQueryString(requestUri.Query);

            // Optional
            if (additionalData.Count > 0)
            {
                query["data"] = String.Join(',', additionalData);
            }

            requestUri.Query = query.ToString();

            var response = await httpClient.GetAsync(requestUri.Uri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<FreeCompanyGetResult>();
            }
            else
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new HttpRequestException($"Remote service returned not found at {response.RequestMessage.RequestUri}", null, HttpStatusCode.NotFound);
                    case HttpStatusCode.TooManyRequests:
                        throw new HttpRequestException($"Rate limited by remote service.", null, HttpStatusCode.TooManyRequests);
                    case HttpStatusCode.ServiceUnavailable:
                        throw new HttpRequestException($"Remote service under mainenance.", null, HttpStatusCode.ServiceUnavailable);
                    default:
                        throw new HttpRequestException($"Remote service returned non-success error code {response.StatusCode} with content {response.Content}", null, response.StatusCode);
                }
            }
        }
    }
}

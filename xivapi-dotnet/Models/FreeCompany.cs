using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;

namespace xivapi
{
    public class FreeCompanySearchResult
    {
        public IList<Uri> Crest { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class FreeCompanyGetResult
    {
        public FreeCompany FreeCompany { get; set; }
        public IList<LightCharacter>? FreeCompanyMembers { get; set; }

        public override string ToString()
        {
            return FreeCompany.Name;
        }
    }

    public class FreeCompany
    {
        public string Active { get; set; }
        public int ActiveMemberCount { get; set; }
        public IList<Uri> Crest { get; set; }
        public string DC { get; set; }
        public Estate Estate { get; set; }
        public IList<Focus> Focus { get; set; }
        public long Formed { get; set; }
        public string GrandCompany { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public long ParseDate { get; set; } // This is just the current Unix time?
        public int Rank { get; set; }
        public Ranking Ranking { get; set; }
        public string Recruitment { get; set; }
        public IList<Reputation> Reputation { get; set; }
        public IList<Seeking> Seeking { get; set; }
        public string Server { get; set; }
        public string Slogan { get; set; }
        public string Tag { get; set; }

        public DateTimeOffset ParseFormedDate()
        {
            return DateTimeOffset.FromUnixTimeSeconds(Formed);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Estate
    {
        public string Greeting { get; set; }
        public string Name { get; set; }
        public string Plot { get; }

        public Plot ParsePlot()
        {
            var splitPlotArray = this.Plot.Split(",");
            return new Plot()
            {
                PlotNumber = splitPlotArray[0],
                WardNumber = splitPlotArray[1],
                HousingArea = splitPlotArray[2]
            };
        }
        public override string ToString()
        {
            return $"{Name}: {Plot}";
        }
    }

    public class Plot
    {
        public string PlotNumber { get; set; }
        public string WardNumber { get; set; }
        public string HousingArea { get; set; }
    }

    public class Focus
    {
        public Uri Icon { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Status}";
        }
    }

    public class Ranking
    {
        public int Monthly { get; set; }
        public int Weekly { get; set; }
    }

    public class Reputation
    {
        public string Name { get; set; }
        public int Progress { get; set; }
        public string Rank { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Rank}";
        }
    }

    public class Seeking
    {
        public Uri Icon { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Status}";
        }
    }

    public class LightCharacter
    {
        public Uri Avatar { get; set; }
        public int FeastMatches { get; set; }
        public int ID { get; set; }
        public string? Lang { get; set; }
        public string Rank { get; set; }
        public Uri RankIcon { get; set; }
        public string Server { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public static class FreeCompanyExtensions
    {
        public async static Task<PaginatedResult<FreeCompanySearchResult>> SearchFreeCompany(this XIVAPI api, string searchKey, [Optional] ServerName? serverName, [Optional] int? page)
        {
            UriBuilder requestUri = new UriBuilder($"{api.hostname}/freecompany/search");
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
            if (!String.IsNullOrWhiteSpace(api.apiKey))
            {
                query["private_key"] = api.apiKey;
            }

            requestUri.Query = query.ToString();

            var response = await api.httpClient.GetAsync(requestUri.Uri);

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

        public async static Task<FreeCompanyGetResult> GetFreeCompany(this XIVAPI api, FreeCompanySearchResult searchResult, [Optional] IList<string>? additionalData, [Optional] bool? includeMembers)
        {
            if (additionalData == null)
            {
                additionalData = new List<string>();
            }
            if (!additionalData.Contains("FCM") && includeMembers == true)
            {
                additionalData.Add("FCM");
            }
            return await GetFreeCompany(api, searchResult.ID, additionalData);
        }

        public async static Task<FreeCompanyGetResult> GetFreeCompany(this XIVAPI api, string ID, [Optional] IList<string>? additionalData, [Optional] bool? includeMembers)
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
            UriBuilder requestUri = new UriBuilder($"{api.hostname}/freecompany/{ID}");
            var query = HttpUtility.ParseQueryString(requestUri.Query);

            // Optional
            if (additionalData.Count > 0)
            {
                query["data"] = String.Join(',', additionalData);
            }
            if (!String.IsNullOrWhiteSpace(api.apiKey))
            {
                query["private_key"] = api.apiKey;
            }

            requestUri.Query = query.ToString();

            var response = await api.httpClient.GetAsync(requestUri.Uri);

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

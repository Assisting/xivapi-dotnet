using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace xivapi
{
    public class CharacterSearchResult
    {
        public Uri Avatar { get; set; }
        public int FeastMatches { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        // These next 2 fields don't seem to be used?
        public string? Rank { get; set; }
        public string? RankIcon { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class CharacterGetResult
    {
        public Achievements? Achievements { get; set; }
        public bool? AchievementsPublic { get; set; }
        public Character Character { get; set; }
        public FreeCompany? FreeCompany { get; set; }
        public IList<LightCharacter>? FreeCompanyMembers { get; set; }
        public IList<LightCharacter>? Friends { get; set; }
        public bool? FriendsPublic { get; set; }
        public IList<MinionMount>? Minions { get; set; }
        public IList<MinionMount>? Mounts { get; set; }
        //TODO: Find somebody with this field populated
        public dynamic? PvPTeam { get; set; }

        public override string ToString()
        {
            return Character.Name;
        }
    }

    public class Achievements
    {
        public IList<Achievement> List { get; set; }
        public int Points { get; set; }
    }

    public class Achievement
    {
        public long Date { get; set; }
        public int ID { get; set; }

        public DateTimeOffset ParseDate()
        {
            return DateTimeOffset.FromUnixTimeSeconds(Date);
        }
    }

    public class Character
    {
        public ClassJob ActiveClassJob { get; set; }
        public Uri Avatar { get; set; }
        public string Bio { get; set; }
        public IList<ClassJob> ClassJobs { get; set; }
        public ClassJobsBozjan ClassJobsBozjan { get; set; }
        public ClassJobsElemental ClassJobsElemental { get; set; }
        public string DC { get; set; }
        public string FreeCompanyId { get; set; }
        public string FreeCompanyName { get; set; }
        public GearSet GearSet { get; set; }
        public Gender Gender { get; set; }
        public GrandCompany GrandCompany { get; set; }
        public GuardianDeity GuardianDeity { get; set; }
        public int ID { get; set; }
        public string? Lang { get; set; }
        public string Name { get; set; }
        public string Nameday { get; set; }
        public long ParseDate { get; set; }
        public Uri Portrait { get; set; }
        public string? PvPTeamId { get; set; }
        public Race Race { get; set; }
        public string Server { get; set; }
        // There are like a billion of these I'm not making an enum
        public int Title { get; set; }
        public bool TitleTop { get; set; }
        public CityState Town { get; set; }
        public Clan Tribe { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ClassJob
    {
        public int ClassID { get; set; }
        public int ExpLevel { get; set; }
        public int ExpLevelMax { get; set; }
        public bool IsSpecialised { get; set; }
        public int JobID { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public UnlockedState UnlockedState { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class UnlockedState
    {
        /* The following field is null on (and only on) Blue Mage, because the 
         * only people Square Enix hates more than Blue Mages are programmers. */
        public int? ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ClassJobsBozjan
    {
        public int Level { get; set; }
        public int Mettle { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ClassJobsElemental
    {
        public int ExpLEvel { get; set; }
        public int ExpLevelMax { get; set; }
        public int ExpLevelTogo { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class GearSet
    {
        public Attributes Attributes { get; set; }
        public int ClassID { get; set; }
        public Gear Gear { get; set; }
        public string GearKey { get; set; }
        public int JobID { get; set; }
        public int Level { get; set; }
    }

    public class Attributes
    {
        // What is this information even *for*
        [JsonPropertyName("1")]
        public int _1 { get; set; }
        [JsonPropertyName("2")]
        public int _2 { get; set; }
        [JsonPropertyName("3")]
        public int _3 { get; set; }
        [JsonPropertyName("4")]
        public int _4 { get; set; }
        [JsonPropertyName("5")]
        public int _5 { get; set; }
        [JsonPropertyName("6")]
        public int _6 { get; set; }
        [JsonPropertyName("7")]
        public int _7 { get; set; }
        [JsonPropertyName("8")]
        public int _8 { get; set; }
        [JsonPropertyName("19")]
        public int _19 { get; set; }
        [JsonPropertyName("20")]
        public int _20 { get; set; }
        [JsonPropertyName("21")]
        public int _21 { get; set; }
        [JsonPropertyName("22")]
        public int _22 { get; set; }
        [JsonPropertyName("24")]
        public int _24 { get; set; }
        [JsonPropertyName("27")]
        public int _27 { get; set; }
        [JsonPropertyName("33")]
        public int _33 { get; set; }
        [JsonPropertyName("34")]
        public int _34 { get; set; }
        [JsonPropertyName("44")]
        public int _44 { get; set; }
        [JsonPropertyName("45")]
        public int _45 { get; set; }
        [JsonPropertyName("46")]
        public int _46 { get; set; }
    }

    public class Gear
    {
        public GearPiece Body { get; set; }
        public GearPiece Bracelets { get; set; }
        public GearPiece Earrings { get; set; }
        public GearPiece Feet { get; set; }
        public GearPiece Hands { get; set; }
        public GearPiece Head { get; set; }
        public GearPiece Legs { get; set; }
        public GearPiece MainHand { get; set; }
        public GearPiece Necklace { get; set; }
        public GearPiece Ring1 { get; set; }
        public GearPiece Ring2 { get; set; }
        public GearPiece SoulCrystal { get; set; }
    }

    public class GearPiece
    {
        public string? Creator { get; set; }
        public int? Dye { get; set; }
        public int ID { get; set; }
        public IList<int>? Materia { get; set; }
        public int? Mirage { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public class GrandCompany
    {
        public GrandCompanyName NameID { get; set; }
        public GrandCompanyRank RankID { get; set; }
    }

    public enum GrandCompanyName
    {
        Maelstrom = 1,
        TwinAdder = 2,
        ImmortalFlames = 3
    }

    public enum GrandCompanyRank
    {
        PrivateThirdClass = 1,
        PrivateSecondClass = 2,
        PrivateFirstClass = 3,
        Corporal = 4,
        SergeantThirdClass = 5,
        SergeantSecondClass = 6,
        SergeantFirstClass = 7,
        ChiefSergeant = 8,
        SecondLieutenant = 9,
        FirstLieutenant = 10,
        Captain = 11
    }

    public enum GuardianDeity
    {
        Halone = 1,
        Menphina = 2,
        Thaliak = 3,
        Nymeia = 4,
        Llymlaen = 5,
        Oschon = 6,
        Byregot = 7,
        Rhalgr = 8,
        Azeyma = 9,
        Naldthal = 10,
        Nophica = 11,
        Althyk = 12
    }

    public enum Race
    {
        Hyur = 1,
        Elezen = 2,
        Lalafell = 3,
        Miqote = 4,
        Roegadyn = 5,
        AuRa = 6,
        Hrothgar = 7,
        Viera = 8
    }

    public enum CityState
    {
        Limsa = 1,
        Gridania = 2,
        Uldah = 3
    }

    public enum Clan
    {
        Midlander = 1,
        Highlander = 2,
        Wildwood = 3,
        Duskwight = 4,
        Plainsfolk = 5,
        Dunesfolk = 6,
        Seekers = 7,
        Keepers = 8,
        SeaWolves = 9,
        Hellsguard = 10,
        Raen = 11,
        Zaela = 12,
        Helions = 13,
        Lost = 14,
        Rava = 15,
        Veena = 16
    }

    public class MinionMount
    {
        public Uri Icon { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public static class CharacterExtensions
    {
        public async static Task<PaginatedResult<CharacterSearchResult>> SearchCharacter(this XIVAPI api, string searchKey, [Optional] IRegion? serverName, [Optional] int? page)
        {
            UriBuilder requestUri = new UriBuilder($"{api.hostname}/character/search");
            var query = HttpUtility.ParseQueryString(requestUri.Query);

            // Non-optional
            if (String.IsNullOrWhiteSpace(searchKey))
            {
                throw new ArgumentException("Must supply a search key for character.", paramName: "searchKey");
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
                return await response.Content.ReadFromJsonAsync<PaginatedResult<CharacterSearchResult>>();
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

        public async static Task<CharacterGetResult> GetCharacter(this XIVAPI api, CharacterSearchResult searchResult, [Optional] IList<string>? additionalData,
            [Optional] bool? includeAchievements, [Optional] bool? includeFriends, [Optional] bool? includeFreeCompany, [Optional] bool? includeMembers,
            [Optional] bool? includeMountsAndMinions, [Optional] bool? includePVPTeam)
        {
            if (additionalData == null)
            {
                additionalData = new List<string>();
            }
            if (!additionalData.Contains("AC") && includeAchievements == true)
            {
                additionalData.Add("AC");
            }
            if (!additionalData.Contains("FR") && includeFriends == true)
            {
                additionalData.Add("FR");
            }
            if (!additionalData.Contains("FC") && includeFreeCompany == true)
            {
                additionalData.Add("FC");
            }
            if (!additionalData.Contains("FCM") && includeMembers == true)
            {
                additionalData.Add("FCM");
            }
            if (!additionalData.Contains("MIMO") && includeMountsAndMinions == true)
            {
                additionalData.Add("MIMO");
            }
            if (!additionalData.Contains("PVP") && includePVPTeam == true)
            {
                additionalData.Add("PVP");
            }
            return await GetCharacter(api, searchResult.ID, additionalData);
        }

        public async static Task<CharacterGetResult> GetCharacter(this XIVAPI api, int ID, [Optional] IList<string>? additionalData,
            [Optional] bool? includeAchievements, [Optional] bool? includeFriends, [Optional] bool? includeFreeCompany, [Optional] bool? includeMembers,
            [Optional] bool? includeMountsAndMinions, [Optional] bool? includePVPTeam)
        {
            if (additionalData == null)
            {
                additionalData = new List<string>();
            }
            if (!additionalData.Contains("AC") && includeAchievements == true)
            {
                additionalData.Add("AC");
            }
            if (!additionalData.Contains("FR") && includeFriends == true)
            {
                additionalData.Add("FR");
            }
            if (!additionalData.Contains("FC") && includeFreeCompany == true)
            {
                additionalData.Add("FC");
            }
            if (!additionalData.Contains("FCM") && includeMembers == true)
            {
                additionalData.Add("FCM");
            }
            if (!additionalData.Contains("MIMO") && includeMountsAndMinions == true)
            {
                additionalData.Add("MIMO");
            }
            if (!additionalData.Contains("PVP") && includePVPTeam == true)
            {
                additionalData.Add("PVP");
            }

            // Non-optional
            if (ID == 0)
            {
                throw new ArgumentException("Must supply an ID to retrieve a character.", paramName: "ID");
            }
            UriBuilder requestUri = new UriBuilder($"{api.hostname}/character/{ID}");
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
                return await response.Content.ReadFromJsonAsync<CharacterGetResult>();
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

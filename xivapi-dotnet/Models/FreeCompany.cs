using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace xivapi.Models
{
    public class FreeCompanySearchResult
    {
        public IList<Uri> Crest { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
    }

    public class FreeCompanyGetResult
    {
        public FreeCompany FreeCompany { get; set; }
        public IList<FreeCompanyMember>? FreeCompanyMembers { get; set; }
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
    }

    public class Seeking
    {
        public Uri Icon { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }

    public class FreeCompanyMember
    {
        public Uri Avatar { get; set; }
        public int FeastMatches { get; set; }
        public int ID { get; set; }
        public string? Lang { get; set; }
        public string Rank { get; set; }
        public Uri RankIcon { get; set; }
        public string Server { get; set; }
    }
}

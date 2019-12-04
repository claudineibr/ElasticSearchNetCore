using Newtonsoft.Json;
using System;

namespace ElasticSearch.Domain.Classes
{
    public partial class LeadQueryReturn
    {
        public LeadQueryReturn()
        {
        }        
        
        [JsonIgnore]
        public Int32 Id { get; set; }
        public string Date { get; set; }
        public int MoreInfo { get; set; }
        public int Funding { get; set; }
        public int Rent { get; set; }
        public int FavoritesRealty { get; set; }
        public int Chat { get; set; }
        public int LeadEventTracker { get; set; }
        public int Login { get; set; }
        public int Registration { get; set; }
        public int Newsletter { get; set; }
        public int Agency { get; set; }
        public int Quiz { get; set; }
    }
}

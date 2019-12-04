using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class MarketingTypes
    {
        public MarketingTypes()
        {
            Realties = new HashSet<Realties>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<Realties> Realties { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}

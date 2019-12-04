using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class RealtyCompanies
    {
        public int RealtyId { get; set; }
        public int CompanyId { get; set; }
        public bool Master { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

        public virtual Companies Company { get; set; }
        [JsonIgnore]
        public virtual Realties Realty { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ElasticSearch.Domain.Classes
{
    public partial class CompanyRegion
    {
        public int CompanyId { get; set; }
        public int NeighborhoodId { get; set; }
        public int ValueZoneId { get; set; }
        public int LocalityId { get; set; }
        public int StateId { get; set; }
        public int NegotiationType { get; set; }
        [JsonIgnore]
        public virtual Companies Company { get; set; }
    }
}

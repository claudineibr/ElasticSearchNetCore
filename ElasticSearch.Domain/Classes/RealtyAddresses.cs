using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class RealtyAddresses
    {
        public int RealtyId { get; set; }
        public int? GeographicalZoneId { get; set; }
        public int? ValueZoneId { get; set; }
        [JsonIgnore]
        public int? StateId { get; set; }
        [JsonIgnore]
        public int LocalityId { get; set; }
        public int? NeighborhoodId { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int? BulkInsertSessionId { get; set; }

        public virtual GeographicalZones GeographicalZone { get; set; }
        public virtual Localities Locality { get; set; }
        public virtual Neighborhoods Neighborhood { get; set; }
        public virtual States State { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
        public virtual ValueZones ValueZone { get; set; }

        [JsonIgnore]
        public virtual Realties Realty { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class GeographicalZoneLocalities
    {
        public GeographicalZoneLocalities()
        {
            ValueZones = new HashSet<ValueZones>();
            ZipCodeAddresses = new HashSet<ZipCodeAddresses>();
        }

        public int Id { get; set; }
        public int? GeographicalZoneId { get; set; }
        public int? LocalityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }

        [JsonIgnore]
        public virtual ICollection<ValueZones> ValueZones { get; set; }

        public virtual ICollection<ZipCodeAddresses> ZipCodeAddresses { get; set; }
        public virtual GeographicalZones GeographicalZone { get; set; }
        public virtual Localities Locality { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}

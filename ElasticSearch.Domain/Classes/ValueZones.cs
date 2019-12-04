using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ElasticSearch.Domain.Classes
{
    public partial class ValueZones
    {
        public ValueZones()
        {
            NeighborhoodInfoes = new HashSet<NeighborhoodInfoes>();
            Neighborhoods = new HashSet<Neighborhoods>();
            RealtyAddresses = new HashSet<RealtyAddresses>();
            ZipCodeAddresses = new HashSet<ZipCodeAddresses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int LocalityId { get; set; }
        public int GeographicalZoneLocalityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual ICollection<NeighborhoodInfoes> NeighborhoodInfoes { get; set; }

        public virtual ICollection<Neighborhoods> Neighborhoods { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyAddresses> RealtyAddresses { get; set; }

        public virtual ICollection<ZipCodeAddresses> ZipCodeAddresses { get; set; }

        public virtual GeographicalZoneLocalities GeographicalZoneLocality { get; set; }

        public virtual Localities Locality { get; set; }

        public virtual Users UpdatedByUser { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class GeographicalZones
    {
        public GeographicalZones()
        {
            GeographicalZoneLocalities = new HashSet<GeographicalZoneLocalities>();
            RealtyAddresses = new HashSet<RealtyAddresses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual ICollection<GeographicalZoneLocalities> GeographicalZoneLocalities { get; set; }
        public virtual ICollection<RealtyAddresses> RealtyAddresses { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}

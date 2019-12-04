using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class ZipCodeAddresses
    {
        public long Id { get; set; }
        public string Zipcode { get; set; }
        public int? StateId { get; set; }
        public int LocalityId { get; set; }
        public int? NeighborhoodId { get; set; }
        public string StreetType { get; set; }
        public string StreetName { get; set; }
        public string ShortStreetName { get; set; }
        public string InitialNumber { get; set; }
        public string FinalNumber { get; set; }
        public int? ValueZoneId { get; set; }
        public int? GeographicalZoneLocalityId { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual GeographicalZoneLocalities GeographicalZoneLocality { get; set; }
        public virtual Neighborhoods Neighborhood { get; set; }
        public virtual Localities Locality { get; set; }
        public virtual States State { get; set; }
        public virtual Users UpdatedByUser { get; set; }
        public virtual ValueZones ValueZone { get; set; }
    }
}

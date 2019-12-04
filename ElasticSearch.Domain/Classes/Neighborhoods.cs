using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class Neighborhoods
    {
        public Neighborhoods()
        {
            CompanyAddresses = new HashSet<CompanyAddresses>();
            NeighborhoodInfoes = new HashSet<NeighborhoodInfoes>();
            RealtyAddresses = new HashSet<RealtyAddresses>();
            UserAddresses = new HashSet<UserAddresses>();
            ZipCodeAddresses = new HashSet<ZipCodeAddresses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        [JsonIgnore]
        public int LocalityId { get; set; }
        [JsonIgnore]
        public int? StateId { get; set; }
        public int? ValueZoneId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        public string Seoname { get; set; }

        [JsonIgnore]
        public virtual ICollection<CompanyAddresses> CompanyAddresses { get; set; }
        //[JsonIgnore]
        public virtual ICollection<NeighborhoodInfoes> NeighborhoodInfoes { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyAddresses> RealtyAddresses { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserAddresses> UserAddresses { get; set; }
        [JsonIgnore]
        public virtual Localities Locality { get; set; }
        [JsonIgnore]
        public virtual ICollection<ZipCodeAddresses> ZipCodeAddresses { get; set; }
        [JsonIgnore]
        public virtual States State { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual ValueZones ValueZone { get; set; }
    }
}

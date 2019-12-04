using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class Localities
    {
        public Localities()
        {
            CompanyAddresses = new HashSet<CompanyAddresses>();
            GeographicalZoneLocalities = new HashSet<GeographicalZoneLocalities>();
            LocalityInfos = new HashSet<LocalityInfos>();
            Neighborhoods = new HashSet<Neighborhoods>();
            RealtyAddresses = new HashSet<RealtyAddresses>();
            RealtyStandouts = new HashSet<RealtyStandouts>();
            UserApplications = new HashSet<UserApplications>();
            ValueZones = new HashSet<ValueZones>();
            ZipCodeAddresses = new HashSet<ZipCodeAddresses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string ActiveFlag { get; set; }
        public string Type { get; set; }
        public int StateId { get; set; }
        public string ZipCode { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        public string Seoname { get; set; }

        [JsonIgnore]
        public virtual ICollection<CompanyAddresses> CompanyAddresses { get; set; }
        [JsonIgnore]
        public virtual ICollection<GeographicalZoneLocalities> GeographicalZoneLocalities { get; set; }
        [JsonIgnore]
        public virtual ICollection<LocalityInfos> LocalityInfos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Neighborhoods> Neighborhoods { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyAddresses> RealtyAddresses { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyStandouts> RealtyStandouts { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserApplications> UserApplications { get; set; }
        [JsonIgnore]
        public virtual ICollection<ValueZones> ValueZones { get; set; }
        [JsonIgnore]
        public virtual ICollection<ZipCodeAddresses> ZipCodeAddresses { get; set; }

        public virtual States State { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<WorkWithUs> WorkWithUs { get; internal set; }

        [JsonIgnore]
        public virtual IEnumerable<ContactUs> ContactUs { get; internal set; }
    }
}

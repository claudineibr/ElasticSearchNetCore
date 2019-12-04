using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class States
    {
        public States()
        {
            CompanyAddresses = new HashSet<CompanyAddresses>();
            Localities = new HashSet<Localities>();
            Neighborhoods = new HashSet<Neighborhoods>();
            RealtyAddresses = new HashSet<RealtyAddresses>();
            UserApplications = new HashSet<UserApplications>();
            ZipCodeAddresses = new HashSet<ZipCodeAddresses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Sa { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public bool? HasValueZone { get; set; }

        [JsonIgnore]
        public virtual ICollection<CompanyAddresses> CompanyAddresses { get; set; }
        [JsonIgnore]
        public virtual ICollection<Localities> Localities { get; set; }
        [JsonIgnore]
        public virtual ICollection<Neighborhoods> Neighborhoods { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyAddresses> RealtyAddresses { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserApplications> UserApplications { get; set; }
        [JsonIgnore]
        public virtual ICollection<ZipCodeAddresses> ZipCodeAddresses { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<WorkWithUs> WorkWithUs { get; internal set; }

        [JsonIgnore]
        public virtual IEnumerable<ContactUs> ContactUs { get; internal set; }
    }
}

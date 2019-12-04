using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public class Stakeholders
    {
        public Stakeholders()
        {
            RealtyStakeholders = new HashSet<RealtyStakeholders>();
            UserApplications = new HashSet<UserApplications>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public int? PersonId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Parameter { get; set; }
        public string LogoPath { get; set; }
        public bool Processed { get; set; }
        public string Ddd { get; set; }
        public string Phone { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal? SearchScore { get; set; }

        [JsonIgnore]
        public virtual ICollection<RealtyStakeholders> RealtyStakeholders { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserApplications> UserApplications { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}

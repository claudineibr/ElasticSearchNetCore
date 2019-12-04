using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class Applications
    {
        public Applications()
        {
            Leads = new HashSet<Leads>();
            UserApplications = new HashSet<UserApplications>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }
        public string Description { get; set; }
        public string ApplicationKey { get; set; }
        public string ApplicationSecret { get; set; }
        public int? Permissions { get; set; }
        public int? CompanyId { get; set; }
        public int? CompanyGroupId { get; set; }

        public virtual ICollection<Leads> Leads { get; set; }
        public virtual ICollection<LeadsGauge> LeadsGauge { get; set; }
        public virtual ICollection<UserApplications> UserApplications { get; set; }
        public virtual CompanyGroups CompanyGroup { get; set; }
        public virtual Companies Company { get; set; }
        public virtual Users UpdatedByUser { get; set; }
        public virtual IEnumerable<WorkWithUs> WorkWithUs { get; internal set; }
        [JsonIgnore]
        public virtual IEnumerable<ContactUs> ContactUs { get; internal set; }
    }
}

using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class CompanyGroups
    {
        public CompanyGroups()
        {
            Applications = new HashSet<Applications>();
            CompanyCompanyGroups = new HashSet<CompanyCompanyGroups>();
            RealtyStandouts = new HashSet<RealtyStandouts>();
            UserApplications = new HashSet<UserApplications>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual ICollection<Applications> Applications { get; set; }
        public virtual ICollection<CompanyCompanyGroups> CompanyCompanyGroups { get; set; }
        public virtual ICollection<RealtyStandouts> RealtyStandouts { get; set; }
        public virtual ICollection<UserApplications> UserApplications { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}

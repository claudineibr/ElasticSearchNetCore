using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class Companies
    {
        public Companies()
        {
            Applications = new HashSet<Applications>();
            Brokers = new HashSet<Brokers>();
            CompanyCompanyGroups = new HashSet<CompanyCompanyGroups>();
            ContactChannels = new HashSet<ContactChannels>();
            RealtyCompanies = new HashSet<RealtyCompanies>();
            UserApplications = new HashSet<UserApplications>();
        }

        public int Id { get; set; }
        public int Reference { get; set; }
        public string Name { get; set; }
        public int? SubsidiaryTypeId { get; set; }
        public string Phone { get; set; }
        public string ResponsibleEmail { get; set; }
        public string MoreInformationEmail { get; set; }
        public string LoadConsistencyEmail { get; set; }
        public string Creci { get; set; }
        public string FullName { get; set; }
        public bool? CrediProntoPartner { get; set; }
        public int? CrmCompanyId { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        public decimal? SearchScore { get; set; }
        public string BaseUrl { get; set; }
        public string Nickname { get; set; }
        public int? LopesNetTerceiros { get; set; }

        public virtual ICollection<Applications> Applications { get; set; }
        [JsonIgnore]
        public virtual ICollection<Brokers> Brokers { get; set; }
        public virtual CompanyAddresses CompanyAddresses { get; set; }
        public virtual ICollection<CompanyCompanyGroups> CompanyCompanyGroups { get; set; }
        public virtual ICollection<CompanyRegion> CompanyRegion { get; set; }
        public virtual ICollection<ContactChannels> ContactChannels { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyCompanies> RealtyCompanies { get; set; }
        public virtual ICollection<UserApplications> UserApplications { get; set; }
        public virtual SubsidiaryTypes SubsidiaryType { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}

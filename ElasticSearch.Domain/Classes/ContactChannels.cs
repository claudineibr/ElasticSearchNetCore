using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class ContactChannels
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public int? LocalityId { get; set; }
        public int? CompanyId { get; set; }
        public int? SourceSiteId { get; set; }
        public int? ChatCompanyId { get; set; }
        public int? ChatDepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public string CallYouPhoneNumber { get; set; }
        public string CallYouUrl { get; set; }
        public string Email { get; set; }
        public string ResponsableName { get; set; }
        public string ResponsableEmail { get; set; }
        public string ResponsablePhone { get; set; }
        public string AutomaticFlag { get; set; }
        public string AltitudeFlag { get; set; }
        public int? CallYouLopesUserId { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        public string Logo { get; set; }
        public bool? TwentyFourForSeven { get; set; }
        public bool? HaveChat { get; set; }
        public string Skype { get; set; }
        public string WhatsAppNumber { get; set; }
        public int? RentCompanyId { get; set; }
        public int? ChatVersionId { get; set; }

        public virtual ChatVersions ChatVersion { get; set; }
        [JsonIgnore]
        public virtual Companies Company { get; set; }
        [JsonIgnore]
        public virtual ContactChannels IdNavigation { get; set; }
        [JsonIgnore]
        public virtual ContactChannels InverseIdNavigation { get; set; }
        public virtual SourceSites SourceSite { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}

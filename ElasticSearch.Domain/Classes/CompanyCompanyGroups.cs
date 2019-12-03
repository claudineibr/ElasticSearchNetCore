using Newtonsoft.Json;
using System;

namespace ElasticSearch.Domain.Classes
{
    public class CompanyCompanyGroups
    {
        public int CompanyId { get; set; }
        public int CompanyGroupId { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual CompanyGroups CompanyGroup { get; set; }
        [JsonIgnore]
        public virtual Companies Company { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}
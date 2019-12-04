using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class RealtyStakeholders
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int RealtyId { get; set; }
        public int StakeholderId { get; set; }
        public int StakeholderTypeId { get; set; }
        public bool MainFlag { get; set; }
        public bool MainStakeholderFlag { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual Realties Realty { get; set; }
        public virtual Stakeholders Stakeholder { get; set; }
        public virtual StakeholderTypes StakeholderType { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}

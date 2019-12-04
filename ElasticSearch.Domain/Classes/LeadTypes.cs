using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class LeadTypes
    {
        public LeadTypes()
        {
            Leads = new HashSet<Leads>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual ICollection<Leads> Leads { get; set; }
        public virtual ICollection<LeadsGauge> LeadsGauge { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}

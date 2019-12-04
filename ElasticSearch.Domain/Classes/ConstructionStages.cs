using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class ConstructionStages
    {
        public ConstructionStages()
        {
            RealtyDivisions = new HashSet<RealtyDivisions>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<RealtyDivisions> RealtyDivisions { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}

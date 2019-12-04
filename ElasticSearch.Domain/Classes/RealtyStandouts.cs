using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class RealtyStandouts
    {
        public int Id { get; set; }
        public int RealtyId { get; set; }
        public int? LocalityId { get; set; }
        public int? StateId { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? BulkInsertSessionId { get; set; }
        public int? CompanyGroupId { get; set; }

        public virtual CompanyGroups CompanyGroup { get; set; }
        public virtual Localities Locality { get; set; }
        public virtual Realties Realty { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}

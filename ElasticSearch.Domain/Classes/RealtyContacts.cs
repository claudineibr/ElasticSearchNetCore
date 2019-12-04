using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class RealtyContacts
    {
        public int RealtyId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? BulkInsertSessionId { get; set; }

        public virtual Realties Realty { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}

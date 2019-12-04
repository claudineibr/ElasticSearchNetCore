using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class BrokerActiveRealties
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        public int? RealtyId { get; set; }
        [JsonIgnore]
        public int? BulkInsertSessionId { get; set; }

        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
        public virtual Users User { get; set; }

        [JsonIgnore]
        public virtual Realties Realty { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class BrokerReviews
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public int Note { get; set; }
        public int PublishStatusId { get; set; }
        public int BrokerId { get; set; }
        public int UserId { get; set; }
        public int? ApprovalUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime? ApprovalAt { get; set; }

        [JsonIgnore]
        public virtual Users ApprovalUser { get; set; }
        [JsonIgnore]
        public virtual Users Broker { get; set; }
        [JsonIgnore]
        public virtual PublishStatus PublishStatus { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual Users User { get; set; }
    }
}

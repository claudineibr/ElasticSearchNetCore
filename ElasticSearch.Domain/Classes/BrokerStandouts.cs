using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class BrokerStandouts
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int? Assortment { get; set; }
        public int? BrokerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Users Broker { get; set; }
    }
}

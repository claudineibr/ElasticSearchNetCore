using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class LocalityInfos
    {
        public int Id { get; set; }
        public int LocalityId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual Localities Locality { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}

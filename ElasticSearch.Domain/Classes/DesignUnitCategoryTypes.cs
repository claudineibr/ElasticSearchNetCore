using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class DesignUnitCategoryTypes
    {
        public int CategoryTypeId { get; set; }
        public int DesignUnitId { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int? BulkInsertSessionId { get; set; }

        public virtual CategoryTypes CategoryType { get; set; }
        [JsonIgnore]
        public virtual DesignUnits DesignUnit { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}

﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElasticSearch.Domain.Classes
{
    public partial class RealtyAttributes
    {
        [JsonIgnore]
        public int RealtyId { get; set; }
        
        public int AttributeId { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int? BulkInsertSessionId { get; set; }

        public virtual Attributes Attribute { get; set; }

        [JsonIgnore]
        public virtual Realties Realty { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}

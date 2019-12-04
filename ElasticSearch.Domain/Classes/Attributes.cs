using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElasticSearch.Domain.Classes
{
    public partial class Attributes
    {
        public Attributes()
        {
            AttributeDescriptions = new HashSet<AttributeDescriptions>();
            DesignUnitMultimedia = new HashSet<DesignUnitMultimedia>();
            DivisionMultimedia = new HashSet<DivisionMultimedia>();
            RealtyAttributes = new HashSet<RealtyAttributes>();
            RealtyMultimedia = new HashSet<RealtyMultimedia>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public int? AttributeCategoryId { get; set; }
        [JsonIgnore]
        public string Description { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<AttributeDescriptions> AttributeDescriptions { get; set; }
        [JsonIgnore]
        public virtual ICollection<DesignUnitMultimedia> DesignUnitMultimedia { get; set; }
        [JsonIgnore]
        public virtual ICollection<DivisionMultimedia> DivisionMultimedia { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyMultimedia> RealtyMultimedia { get; set; }
        [JsonIgnore]
        public virtual AttributeCategories AttributeCategory { get; set; }

        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyAttributes> RealtyAttributes { get; set; }
    }
}

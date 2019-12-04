using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class DesignUnitMultimedia
    {
        public int Id { get; set; }
        public int DesignUnitId { get; set; }
        public int? AttributeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
        public DateTime? MultimediaDate { get; set; }
        public int? MultimediaSubtypeId { get; set; }
        public string Seopath { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int PublishStatusId { get; set; }
        public int Assortment { get; set; }

        public virtual Attributes Attribute { get; set; }
        [JsonIgnore]
        public virtual DesignUnits DesignUnit { get; set; }
        public virtual MultimediaSubTypes MultimediaSubtype { get; set; }
        public virtual PublishStatus PublishStatus { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}

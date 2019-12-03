using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElasticSearch.Domain.Classes
{
    public class RealtyMultimedia
    {

        [JsonIgnore]
        public int Id { get; set; }
        public string Reference { get; set; }
        public int? RealtyId { get; set; }
        [JsonIgnore]
        public int? AttributeId { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
        [JsonIgnore]
        public DateTime? MultimediaDate { get; set; }
        public int? MultimediaSubtypeId { get; set; }
        public string Seopath { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int? BulkInsertSessionId { get; set; }
        // [JsonIgnore]
        public int? PublishStatusId { get; set; }
        public int Assortment { get; set; }

        [NotMapped]
        public bool AlwaysShow { get; set; }

        [NotMapped]
        public String Title { get; set; }

        [JsonIgnore]
        public virtual Attributes Attribute { get; set; }
        [JsonIgnore]
        public virtual MultimediaSubTypes MultimediaSubtype { get; set; }
        [JsonIgnore]
        public virtual PublishStatus PublishStatus { get; set; }
        [JsonIgnore]
        public virtual Realties Realty { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}
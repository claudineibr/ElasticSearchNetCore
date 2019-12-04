using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class NeighborhoodInfoes
    {
        private String _Description = string.Empty;
        public int Id { get; set; }
        public int? NeighborhoodId { get; set; }
        public int? ValueZoneId { get; set; }
        public string Description {
            get {
                if (String.IsNullOrEmpty(_Description))
                    return string.Empty;
                else
                    return _Description.Trim();
                 }
            set {
                _Description = value;
            } }
        public bool? MainFlag { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public virtual Neighborhoods Neighborhood { get; set; }
        public virtual Users UpdatedByUser { get; set; }

        [JsonIgnore]
        public virtual ValueZones ValueZone { get; set; }
    }
}

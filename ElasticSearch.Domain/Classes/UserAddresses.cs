using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class UserAddresses
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int LocalityId { get; set; }
        public int NeighborhoodId { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

        public virtual Neighborhoods Neighborhood { get; set; }
        public virtual Localities Locality { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual Users User { get; set; }
    }
}

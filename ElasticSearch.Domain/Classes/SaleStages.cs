using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElasticSearch.Domain.Classes
{
    public partial class SaleStages
    {
        public SaleStages()
        {
            Realties = new HashSet<Realties>();
            RealtyDivisions = new HashSet<RealtyDivisions>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<Realties> Realties { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyDivisions> RealtyDivisions { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}

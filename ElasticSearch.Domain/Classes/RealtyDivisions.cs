using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class RealtyDivisions
    {
        public RealtyDivisions()
        {
            DesignUnits = new HashSet<DesignUnits>();
            DivisionMultimedia = new HashSet<DivisionMultimedia>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
        public int? SaleStageId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? StartWorkDate { get; set; }
        public DateTime? DeliveryKeysDate { get; set; }
        public DateTime? InitialForecastDeliveryDate { get; set; }
        public DateTime? AjustedForecastDeliveryDate { get; set; }
        public int? QtyUnits { get; set; }
        public int? QtyFloors { get; set; }
        public int? QtyUnitsByFloor { get; set; }
        public int? QtyElevators { get; set; }
        [JsonIgnore]
        public int RealtyId { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        public int? ConstructionStageId { get; set; }
        [JsonIgnore]
        public int? BulkInsertSessionId { get; set; }

        public virtual ICollection<DesignUnits> DesignUnits { get; set; }
        public virtual ICollection<DivisionMultimedia> DivisionMultimedia { get; set; }
        public virtual ConstructionStages ConstructionStage { get; set; }
        [JsonIgnore]
        public virtual Realties Realty { get; set; }
        public virtual SaleStages SaleStage { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}

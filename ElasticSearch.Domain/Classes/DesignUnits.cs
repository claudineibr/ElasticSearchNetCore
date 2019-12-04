using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class DesignUnits
    {
        public DesignUnits()
        {
            DesignUnitCategoryTypes = new HashSet<DesignUnitCategoryTypes>();
            DesignUnitMultimedia = new HashSet<DesignUnitMultimedia>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PrivateArea { get; set; }
        public decimal? TotalArea { get; set; }
        public decimal? SquareMeterValue { get; set; }
        public int? QtyDemarkedVacancies { get; set; }
        public int? QtyNotDemarkedVacancies { get; set; }
        public int? QtyBedrooms { get; set; }
        public int? QtySuites { get; set; }
        public int? QtyRooms { get; set; }
        public int? QtySocialBathrooms { get; set; }
        public int? QtyKitchens { get; set; }
        public int DivisionId { get; set; }
        public decimal? Price { get; set; }
        public decimal? MonthlyRent { get; set; }
        public decimal? MunicipalTax { get; set; }
        public decimal? CondominiumFees { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int? BulkInsertSessionId { get; set; }

        public virtual DesignFunding DesignFunding { get; set; }
        public virtual ICollection<DesignUnitCategoryTypes> DesignUnitCategoryTypes { get; set; }
        public virtual ICollection<DesignUnitMultimedia> DesignUnitMultimedia { get; set; }
        [JsonIgnore]
        public virtual RealtyDivisions Division { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}

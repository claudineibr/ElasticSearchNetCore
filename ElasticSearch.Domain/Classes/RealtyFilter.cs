using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public class RealtyFilter
    {
        public int? RealtyId { get; set; } = -1;
        public int? BrokerId { get; set; } = -1;
        public int? ValueZoneId { get; set; } = -1;
        public int? NeighborhoodId { get; set; } = -1;
        public string NeighborhoodName { get; set; } = "";
        public int? MarketingTypeId { get; set; } = -1;
        public int? LocalityId { get; set; } = -1;
        public string LocalityName { get; set; } = "";
        public int? StateId { get; set; } = -1;
        public string StateSA { get; set; } = "";
        public int? CategoryId { get; set; } = -1;

        public string[] Categories { get; set; }

        public virtual ICollection<RealtyAttributes> AttributeList { get; set; }
        public decimal? PriceLow { get; set; } = 0;
        public decimal? PriceHigh { get; set; } = 0;
        public decimal? MonthlyRentLow { get; set; } = 0;
        public decimal? MonthlyRentHigh { get; set; } = 0;
        public decimal? PrivateAreaLow { get; set; } = 0;
        public decimal? PrivateAreaHigh { get; set; } = 0;
        public int? QtyBedrooms { get; set; } = -1;
        public int? QtySuites { get; set; } = -1;
        public int? QtyDemarkedVacancies { get; set; } = -1;
        public int? GeographicalZoneId { get; set; }
        public string GeographicalZoneName { get; set; }
        public List<int?> QtyBedroomsList { get; set; }
        public List<int?> QtySuitesList { get; set; }
        public List<int?> QtyDemarkedVacanciesList { get; set; }
    }
}
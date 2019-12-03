using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElasticSearch.Domain.Classes
{
    public class Realties
    {
        private String _Title = string.Empty;

        public Realties()
        {
            RealtyAttributes = new HashSet<RealtyAttributes>();
            RealtyCompanies = new HashSet<RealtyCompanies>();
            RealtyDivisions = new HashSet<RealtyDivisions>();
            RealtyMultimedia = new HashSet<RealtyMultimedia>();
            RealtyStakeholders = new HashSet<RealtyStakeholders>();
            RealtyStandouts = new HashSet<RealtyStandouts>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
        public int? SaleStageId { get; set; }
        public decimal? TotalArea { get; set; }
        public decimal? SquareMeterAvaregeValue { get; set; }
        public int MarketingTypeId { get; set; }
        public int? QtyVisits { get; set; }
        public string FriendlyUrl { get; set; }
        public bool? Competitor { get; set; }
        public bool HasOwner { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Discriminator { get; set; }
        public bool? Exclusivity { get; set; }
        public string Hash { get; set; }
        [JsonIgnore]
        public int? BulkInsertSessionId { get; set; }
        public int PublishStatusId { get; set; }
        public decimal? Ranking { get; set; }
        public decimal? Booster { get; set; }
        public string DescriptionMarketing { get; set; }
        public decimal? QualityRanking { get; set; }
        public bool? ExclusiveChat { get; set; }
        public int? QtyDesign { get; set; }
        public decimal? BestPrice { get; set; }
        public decimal? BestRent { get; set; }

        public int? QtyBedrooms { get; set; }
        public int? QtyDemarkedVacancies { get; set; }
        public int? QtySuites { get; set; }

        public int? QtyBedroomsMax { get; set; }
        public int? QtyDemarkedVacanciesMax { get; set; }
        public int? QtySuitesMax { get; set; }

        public int? QtyRealtyMultimedia { get; set; }
        public decimal? PrivateArea { get; set; }
        public decimal? PrivateAreaMax { get; set; }
        public int? NeighborhoodId { get; set; }
        public int? ValueZoneId { get; set; }
        public int? LocalityId { get; set; }
        public int? StateId { get; set; }
        public int? CategoryId { get; set; }
        public string Title
        {
            get { return null; }
            set { _Title = value; }
        }

        public virtual RealtyAddresses RealtyAddresses { get; set; }
        public virtual MarketingTypes MarketingType { get; set; }
        public virtual SaleStages SaleStage { get; set; }

        [NotMapped]
        public virtual ICollection<RealtyStandouts> RealtyStandouts { get; set; }
        [NotMapped]
        public int? Company_Id { get; set; }
        [NotMapped]
        public bool? ReferenceWithoutPrefix { get; set; }
        [NotMapped]
        public virtual RealtyContacts RealtyContacts { get; set; }

        [NotMapped]
        public SEOResultSet SEOResultSet { get; set; }

        [NotMapped]
        public int MinQtyBedrooms { get; set; }

        [NotMapped]
        public int MaxQtyBedrooms { get; set; }

        [NotMapped]
        public int MinQtySuites { get; set; }

        [NotMapped]
        public int MaxQtySuites { get; set; }

        [NotMapped]
        public int MinQtyDemarkedVacancies { get; set; }

        [NotMapped]
        public int MaxQtyDemarkedVacancies { get; set; }

        [NotMapped]
        public decimal MinPrivateArea { get; set; }

        [NotMapped]
        public decimal MaxPrivateArea { get; set; }

        [NotMapped]
        public int MinQtySocialBathrooms { get; set; }

        [NotMapped]
        public int MaxQtySocialBathrooms { get; set; }

        [NotMapped]
        public string UrlSeo { get; set; }

        public virtual ICollection<RealtyAttributes> RealtyAttributes { get; set; }
        public virtual ICollection<RealtyCompanies> RealtyCompanies { get; set; }
        public virtual ICollection<RealtyDivisions> RealtyDivisions { get; set; }
        public virtual ICollection<RealtyMultimedia> RealtyMultimedia { get; set; }

        [NotMapped]
        public virtual ICollection<RealtyMultimedia> RealtyMultimediaVideos { get; set; }

        //[JsonIgnore]
        public virtual ICollection<RealtyStakeholders> RealtyStakeholders { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrokerActiveRealties> BrokerActiveRealties { get; set; }
        [JsonIgnore]
        public virtual PublishStatus PublishStatus { get; set; }

        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<ContactUs> ContactUs { get; internal set; }
    }
}
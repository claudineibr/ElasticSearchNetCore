using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class RealtiesDeleted
    {
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
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Discriminator { get; set; }
        public bool? Exclusivity { get; set; }
        public string Hash { get; set; }
        public int? BulkInsertSessionId { get; set; }
        public int PublishStatusId { get; set; }
        public decimal? Ranking { get; set; }
        public decimal? Booster { get; set; }
        public string DescriptionMarketing { get; set; }
        public decimal? QualityRanking { get; set; }
        public bool? ExclusiveChat { get; set; }
        public DateTime DeletedDate { get; set; }
        public string DeletedUsr { get; set; }
    }
}

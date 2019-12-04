using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class PromotedRealties
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int UserId { get; set; }
        public string PaymentReference { get; set; }
        public decimal PaymentAmount { get; set; }
        public int PaymentStatusId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }
        public int? AdvertisementTypeId { get; set; }
        public int? Ranking { get; set; }
        public string ThirdPartReference { get; set; }
        public int? OperationTypeId { get; set; }
        public DateTime? DateRenewalNotice { get; set; }
        public DateTime? DateCancellationNotice { get; set; }
    }
}

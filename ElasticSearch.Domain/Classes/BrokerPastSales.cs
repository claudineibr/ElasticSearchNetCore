using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class BrokerPastSales
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullAddress { get; set; }
        public string RealtyDescription { get; set; }
        public string StandoutMultimedia { get; set; }
        public decimal Price { get; set; }
        public DateTime SoldDate { get; set; }
        public string Reference { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual Users UpdatedByUser { get; set; }
        public virtual Users User { get; set; }
    }
}

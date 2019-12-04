using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElasticSearch.Domain.Classes
{
    public partial class Brokers
    {
        private String _PhotoPath = string.Empty;
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public decimal? Ranking { get; set; }
        public decimal? AverageRating { get; set; }

        [NotMapped]
        public bool HasBuy { get; set; }
        [NotMapped]
        public bool HasRent { get; set; }
        [NotMapped]
        public bool HasLancamentos { get; set; }

        [NotMapped]
        public List<BrokerReviews> BrokerReviews { get; set; }

        public string PhotoPath {
            get {

                if(this.User != null)
                    return String.Format(@"https://crm.lopesnet.com.br/geral/thumb.aspx?file={0}.jpg&w=160&h=214", this.User.Reference);
                else
                    return  String.Format(@"https://crm.lopesnet.com.br/geral/thumb.aspx?file={0}.jpg&w=160&h=214", "1234567890");
            }
            set { _PhotoPath = value; } }

        [NotMapped]
        public string Creci { get; set; }

        public IEnumerable<NeighborhoodResultSet> Neighborhoods { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }

        public virtual Companies Company { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
        public virtual Users User { get; set; }
        
    }
}

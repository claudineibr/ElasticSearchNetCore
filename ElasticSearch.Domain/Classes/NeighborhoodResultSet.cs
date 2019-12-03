using System.ComponentModel.DataAnnotations;

namespace ElasticSearch.Domain.Classes
{
    public class NeighborhoodResultSet
    {
        [Key]
        public int NeighborhoodId { get; set; }
        public string NeighborhoodName { get; set; }
        public string Seoname { get; set; }
        public string NickName { get; set; }
        public int ValueZoneId { get; set; }
        public string ValueZoneName { get; set; }
        public int LocalityId { get; set; }
        public string LocalityName { get; set; }
        public string LocalityNameSeoname { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateSA { get; set; }
        public int CountRealties { get; set; }
    }
}
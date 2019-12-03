using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public class SEOResultSet
    {
        public string SiteNameSeo { get; set; }
        public string PhoneNumberSeo { get; set; }
        public double LatitudeSeo { get; set; }
        public double LongitudeSeo { get; set; }
        public string KeywordsSeo { get; set; }
        public string DescriptionSeo { get; set; }
        public string TitleSeo { get; set; }
        public string ImageSeo { get; set; }
        public ICollection<NeighborhoodResultSet> CloseNeighborhoods { get; set; }
        public ICollection<NeighborhoodResultSet> CloseLocalities { get; set; }
    }
}
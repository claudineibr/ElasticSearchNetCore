using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public class PagedRealtyFilter
    {
        public int CurrentPage { get; set; } = 1;
        public string SortType { get; set; }
        public int ApplicationId { get; set; }

        public SEOResultSet SEOResultSet { get; set; }

        public virtual ICollection<RealtyFilter> RealtyFilterList { get; set; }
    }
}

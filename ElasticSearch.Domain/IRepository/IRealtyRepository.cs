using ElasticSearch.Domain.Classes;
using System.Collections.Generic;

namespace ElasticSearch.Domain.IRepository
{
    public interface IRealtyRepository
    {
        List<Realties> GetAll();
    }
}

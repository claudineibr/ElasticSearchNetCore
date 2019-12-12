using ElasticSearch.Domain.Classes;
using ElasticSearch.Domain.IRepository;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ElasticSearch.Repository.Repositories
{
    public class RealtyRepository : IRealtyRepository
    {
        public List<Realties> GetAll()
        {
            return JsonConvert.DeserializeObject<List<Realties>>(File.ReadAllText("./imoveis.json"));
        }
    }
}

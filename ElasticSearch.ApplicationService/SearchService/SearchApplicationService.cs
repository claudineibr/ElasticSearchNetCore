using ElasticSearch.Domain.Classes;
using ElasticSearch.Domain.IApplicationService;
using ElasticSearch.Domain.IRepository;
using ElasticSearch.Domain.ViewModel;
using Microsoft.Extensions.Configuration;
using Nest;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.ApplicationService.SearchService
{
    public class SearchApplicationService : ISearchApplicationService
    {
        private readonly IProductRepository productRepository;
        private readonly IElasticClient elasticClient;
        private readonly IConfiguration configuration;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly string defaultIndex = string.Empty;
        public SearchApplicationService(IProductRepository productRepository,
                                        IElasticClient elasticClient,
                                        IConfiguration configuration)
        {
            this.productRepository = productRepository;
            this.elasticClient = elasticClient;
            this.configuration = configuration;
            defaultIndex = configuration["elasticsearch:index"];
        }

        public async Task<List<Realties>> All()
        {
            //var count = await elasticClient.SearchAsync<Realties>(s => s.Index(defaultIndex).Scroll("1m").Size(10000).MatchAll());
            //var total = count.Documents.Count();
            var response = await elasticClient.SearchAsync<Realties>(s => s.Index(defaultIndex).MatchAll());

            return response.Documents.ToList();
        }

        public async Task<List<ProductViewModel>> Find(FilterProductViewModel filter)
        {
            var response = await elasticClient.SearchAsync<ProductViewModel>(
                  s => s.Index(defaultIndex).Query(q => q.Term(t => t.Name, filter.Name?.ToLower())));

            return response.Documents.ToList();
        }

        public async Task<Realties> FindById(string id)
        {

            int.TryParse(id, out int isNumber);

            string search = string.Empty;
            if (isNumber > 0)
                search = string.Format("IM{0}", isNumber);
            else
                search = id;

            var analyzeResponse = elasticClient.Indices.Analyze(a => a
                           .Index(defaultIndex)
                           .Field<Realties>(f => f.Reference)
                           .Text(isNumber.ToString())
                       );

            var filters = new List<System.Func<QueryContainerDescriptor<Realties>, QueryContainer>>
            {
                fq=> fq.Prefix(p=> p.Reference,search)
                //fq => (fq.Prefix(t => t.Field(f => f.Reference).value(search)) ||
                //       fq.Prefix(t => t.Field(f => f.Name).Query(search))) &&
                //       fq.Terms(t => t.Field(f => f.PublishStatusId).Terms(1))
            };

            filters.Add(fq => fq.Terms(t => t.Field(f => f.RealtyCompanies.Select(rc => rc.Company.CompanyCompanyGroups.Select(xc => xc.CompanyGroupId))).Terms(1)));

            var resultFilter = elasticClient.Search<Realties>(x => x.Index(defaultIndex).Query(q => q.Bool(bq => bq.Filter(filters))));

            if (resultFilter.Documents.Count > 0)
                return resultFilter.Documents.First();

            var any = await elasticClient.GetAsync<Realties>(id, d => d.Index(defaultIndex));
            if (any.Source is null)
            {
                var response = await elasticClient.SearchAsync<Realties>(s => s.Index(defaultIndex).Query(q => q.Term(t => t.Reference, id) || q.Term(t => t.Id, id)));
                if (response.Documents.Count > 0)
                    return response.Documents.First();
            }

            return any.Source;
        }

        public async Task ReIndex()
        {
            //await elasticClient.DeleteByQueryAsync<ProductViewModel>(q => q.Index(defaultIndex).MatchAll());
            //var products = productRepository.GetAll().ToArray();
            //foreach (var product in products)
            //{
            //    await elasticClient.IndexAsync(product, d => d.Index(defaultIndex).Id(product.ProductCode));
            //}
        }

        public async Task ReIndexMany()
        {
            //await elasticClient.DeleteByQueryAsync<ProductViewModel>(q => q.Index("products-many").MatchAll());
            //var products = productRepository.GetAll().ToArray();
            //var indexManyAsyncResponse = await elasticClient.IndexManyAsync(products, "products-many");
            //if (indexManyAsyncResponse.Errors)
            //{
            //    foreach (var itemWithError in indexManyAsyncResponse.ItemsWithErrors)
            //    {
            //        logger.Error("Failed to index document {0}: {1}", itemWithError.Id, itemWithError.Error);
            //    }
            //}
        }

        public async Task ReIndexBulkAsync()
        {
            //await elasticClient.DeleteByQueryAsync<ProductViewModel>(q => q.Index("products").MatchAll());
            //var products = productRepository.GetAll().ToArray();
            //await elasticClient.BulkAsync(b => b.Index("products").IndexMany(products));
        }

        public async Task ReIndexUpdate()
        {
            //var products = productRepository.GetAll().ToArray();

            //foreach (var product in products)
            //{
            //    var any = await elasticClient.DocumentExistsAsync<ProductViewModel>(product.ProductCode);
            //    if (!any.Exists)
            //    {
            //        await elasticClient.IndexDocumentAsync(product);
            //        continue;
            //    }
            //    await elasticClient.UpdateAsync<ProductViewModel>(product.ProductCode, u => u.Index(defaultIndex).Doc(product));
            //}
        }
    }
}
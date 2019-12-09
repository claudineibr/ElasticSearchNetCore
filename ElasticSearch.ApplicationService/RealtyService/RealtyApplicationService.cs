using ElasticSearch.Domain.Classes;
using ElasticSearch.Domain.IApplicationService;
using ElasticSearch.Domain.IRepository;
using ElasticSearch.Domain.Utilities;
using LinqKit;
using Nest;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.ApplicationService.RealtyService
{
    public class RealtyApplicationService : IRealtyApplicationService
    {
        private readonly IRealtyRepository realtyRepository;
        private readonly IElasticClient elasticClient;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private int _companyGroupId = 1;
        private static readonly int PageSize = 12;
        private static readonly int NOFILTER = -1;
        private readonly string indexName = "realty";

        public RealtyApplicationService(IRealtyRepository realtyRepository, IElasticClient elasticClient)
        {
            this.realtyRepository = realtyRepository ?? throw new ArgumentNullException(nameof(realtyRepository));
            this.elasticClient = elasticClient ?? throw new ArgumentNullException(nameof(elasticClient));
        }

        public async Task ReIndex()
        {
            await elasticClient.DeleteByQueryAsync<Realties>(q => q.Index(indexName).MatchAll());

            var realtys = realtyRepository.GetAll().ToArray();
            var indexManyAsyncResponse = await elasticClient.IndexManyAsync(realtys, indexName);
            if (indexManyAsyncResponse.Errors)
            {
                foreach (var itemWithError in indexManyAsyncResponse.ItemsWithErrors)
                {
                    logger.Error("Failed to index document {0}: {1}", itemWithError.Id, itemWithError.Error);
                }
            }
        }

        public async Task<PagedResult<Realties>> GetbyAttrib(PagedRealtyFilter realtyFilter)
        {
            //int currentPage = realtyFilter.CurrentPage;
            //(List<Realties> realties, int marketingTypeId) = await ApplayFilters(realtyFilter);
            //var search = ResultsetOptions.GetPaged(realties.AsQueryable(), currentPage, PageSize);

            //return search;

            return null;
        }


        //private async Task<(List<Realties>, int marketingTypeId)> ApplayFilters(PagedRealtyFilter realtyFilter)
        //{

        //    int marketingTypeId = 1;

        //    if (realtyFilter.ApplicationId <= 0)
        //        realtyFilter.ApplicationId = 1;

        //    var filters = new List<Func<QueryContainerDescriptor<Realties>, QueryContainer>>();

        //    foreach (var realty in realtyFilter.RealtyFilterList)
        //    {
        //        //var ids = GetLocality(realty);

        //        //realty.NeighborhoodId = ids[0];
        //        //realty.LocalityId = ids[1];
        //        //realty.StateId = ids[2];
        //        //realty.GeographicalZoneId = ids[3];
        //        //realty.ValueZoneId = ids[4];

        //        if (!(realty.MarketingTypeId is null))
        //            marketingTypeId = (int)realty.MarketingTypeId;

        //        if (realtyFilter.ApplicationId != 1)
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.RealtyCompanies.Select(rc => rc.Company.CompanyCompanyGroups.Select(xc => xc.CompanyGroupId))).Terms(_companyGroupId)));
        //        else
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.RealtyCompanies.Select(rc => rc.Master)).Terms(true)));

        //        if (realty.Categories != null && realty.Categories.Any())
        //        {
        //            List<int> typesCategories = DeterminaIdCategories(realty.Categories);
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.RealtyDivisions.Select(rc => rc.DesignUnits.Select(ds => ds.DesignUnitCategoryTypes.Select(dsu => dsu.CategoryTypeId)))).Terms(typesCategories)));
        //        }

        //        //Define se é para filtrar por corretor e como
        //        bool filtraCorretor = false;
        //        bool filtraPorCorretorLancamento = false;

        //        Brokers broker = new Brokers();
        //        if (realty.BrokerId != null && realty.BrokerId > 0)
        //        {
        //            broker = _context.Brokers
        //                .Include(x => x.Company)
        //                 .Include(x => x.User)
        //                .Where(x => x.UserId == realty.BrokerId).FirstOrDefault();

        //            if (broker != null)
        //            {
        //                filtraCorretor = true;
        //                if (broker.Company.SubsidiaryTypeId == null)
        //                    filtraPorCorretorLancamento = true;
        //            }
        //        }

        //        if (filtraCorretor)
        //        {
        //            if (filtraPorCorretorLancamento)
        //            {
        //                filters.Add(fq => fq.Terms(t => t.Field(f => f.RealtyCompanies.Select(rc => rc.CompanyId)).Terms(broker.Company.Id)));
        //            }
        //            else
        //            {
        //                //Se tem outra empresa ligada a empresa 
        //                var companiesLancamento = _context.Companies.Where(x => x.CrmCompanyId == broker.Company.CrmCompanyId && x.SubsidiaryTypeId == null).FirstOrDefault();

        //                if (!(companiesLancamento is null) && companiesLancamento.Id > 0)
        //                    filters.Add((fq => fq.Terms(t => t.Field(f => f.BrokerActiveRealties.Select(rc => rc.UserId)).Terms(realty.BrokerId)) || fq.Terms(t => t.Field(f => f.RealtyCompanies.Select(rc => rc.CompanyId)).Terms(companiesLancamento.Id))));
        //                else
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.BrokerActiveRealties.Select(rc => rc.UserId)).Terms(realty.BrokerId)));
        //            }
        //        }

        //        //Construção de Filtros de query
        //        if (realty.RealtyId.HasValue && realty.RealtyId != NOFILTER)
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.Id).Terms(realty.RealtyId)));

        //        if (realty.NeighborhoodId.HasValue && realty.NeighborhoodId != NOFILTER)
        //        {
        //            var zoneName = "";

        //            var neightborhood = GetNeighboorhoodById((int)realty.NeighborhoodId);
        //            neightborhood.ValueZone = !(realty.ValueZoneId is null) ? GetValueZonesById((int)realty.ValueZoneId) : null;

        //            if (!(neightborhood is null) && !(neightborhood.ValueZone is null))
        //            {
        //                realty.ValueZoneId = neightborhood.ValueZone.Id;
        //                zoneName = neightborhood.ValueZone.Name.ToUpper();
        //            }

        //            bool newRealties = (realty.MarketingTypeId.HasValue && realty.MarketingTypeId.Value == 4);

        //            bool searchByZone = (realty.ValueZoneId.HasValue && realty.ValueZoneId != NOFILTER);

        //            bool sameByZone = (zoneName == realty.NeighborhoodName.ToUpper());

        //            if (searchByZone && (newRealties || sameByZone))
        //                filters.Add(fq => fq.Terms(t => t.Field(f => f.ValueZoneId).Terms(realty.ValueZoneId.Value)) || fq.Terms(t => t.Field(f => f.NeighborhoodId).Terms(realty.NeighborhoodId)));
        //            else
        //                filters.Add(fq => fq.Terms(t => t.Field(f => f.NeighborhoodId).Terms(realty.NeighborhoodId))); // NEW LAYOUT
        //        }

        //        if (realty.NeighborhoodId == -1 && realty.ValueZoneId.HasValue && realty.ValueZoneId != NOFILTER)
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.ValueZoneId).Terms(realty.ValueZoneId.Value)));// NEW LAYOUT

        //        //Checa se filtra por Zona Geografica
        //        if ((!realty.NeighborhoodId.HasValue || realty.NeighborhoodId == NOFILTER) && realty.LocalityId.HasValue && realty.LocalityId != NOFILTER && realty.GeographicalZoneId.HasValue && realty.GeographicalZoneId != NOFILTER)
        //        {
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.LocalityId).Terms(realty.LocalityId)));// NEW LAYOUT
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.RealtyAddresses.Neighborhood.ValueZone.GeographicalZoneLocalityId).Terms(realty.GeographicalZoneId)));// NEW LAYOUT
        //        }

        //        if ((!realty.NeighborhoodId.HasValue || realty.NeighborhoodId == NOFILTER) && realty.LocalityId.HasValue && realty.LocalityId != NOFILTER && ((!realty.GeographicalZoneId.HasValue || realty.GeographicalZoneId == NOFILTER)))
        //            filters.Add((fq => fq.Terms(t => t.Field(f => f.LocalityId).Terms(realty.LocalityId))));// NEW LAYOUT

        //        if ((!realty.NeighborhoodId.HasValue || realty.NeighborhoodId == NOFILTER) && (!realty.LocalityId.HasValue || realty.LocalityId == NOFILTER) && realty.StateId.HasValue && realty.StateId != NOFILTER)
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.StateId).Terms(realty.StateId)));// NEW LAYOUT

        //        if (realty.CategoryId.HasValue && realty.CategoryId != NOFILTER)
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.CategoryId).Terms(realty.CategoryId)));// NEW LAYOUT

        //        if (!(realty.AttributeList is null))
        //        {
        //            foreach (var att in realty.AttributeList)
        //                filters.Add(fq => fq.Terms(t => t.Field(f => f.RealtyAttributes.Select(s => s.AttributeId)).Terms(att.AttributeId)));
        //        }

        //        bool hasOwner = (realty.MarketingTypeId != 4);
        //        if (realty.MarketingTypeId.HasValue && realty.MarketingTypeId != NOFILTER)
        //        {
        //            List<int> types = new List<int> { 1, 2, 3 };
        //            switch (realty.MarketingTypeId)
        //            {
        //                case 1:
        //                    types = new List<int> { 1, 2 };
        //                    break;
        //                case 3:
        //                    types = new List<int> { 2, 3 };
        //                    break;
        //                case 4:
        //                    types = new List<int> { 1 };
        //                    break;
        //            }
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.MarketingType).Terms(types)) &&
        //                              fq.Terms(t => t.Field(f => f.HasOwner).Terms(hasOwner)));
        //        }

        //        if (realty.QtyBedrooms.HasValue && realty.QtyBedrooms != NOFILTER)
        //        {
        //            if (realty.QtyBedrooms <= 4)
        //                filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedrooms)) &&
        //                                  fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedrooms)));
        //            else
        //                filters.Add(fq => fq.Range(t => t.Field(f => f.QtyBedrooms).GreaterThanOrEquals(realty.QtyBedrooms)));  // NEW LAYOUT
        //        }

        //        if (realty.QtySuites.HasValue && realty.QtySuites != NOFILTER)
        //        {
        //            if (realty.QtySuites <= 4)
        //                filters.Add(fq => fq.Terms(t => t.Field(f => f.QtySuites).Terms(realty.QtySuites)) ||
        //                                  fq.Terms(t => t.Field(f => f.QtySuitesMax).Terms(realty.QtySuites)));// NEW LAYOUT
        //            else
        //                filters.Add(fq => fq.Range(t => t.Field(f => f.QtySuites).GreaterThanOrEquals(realty.QtySuites))); // NEW LAYOUT
        //        }

        //        if (realty.QtyDemarkedVacancies.HasValue && realty.QtyDemarkedVacancies != NOFILTER)
        //            filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyDemarkedVacancies).Terms(realty.QtyDemarkedVacancies)) ||
        //                              fq.Terms(t => t.Field(f => f.QtyDemarkedVacanciesMax).Terms(realty.QtyDemarkedVacancies))); // NEW LAYOUT

        //        if (realty.QtyBedroomsList != null && realty.QtyBedroomsList.Any())
        //        {
        //            if (realty.QtyBedroomsList.Count == 1)
        //            {
        //                if (realty.QtyBedroomsList[0] <= 4)
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[0]))); // NEW LAYOUT 
        //                else
        //                    filters.Add(fq => fq.Range(t => t.Field(f => f.QtyBedrooms).GreaterThanOrEquals(realty.QtyBedroomsList[0]))); // NEW LAYOUT
        //            }
        //            else if (realty.QtyBedroomsList.Count == 2)
        //            {
        //                if (!realty.QtyBedroomsList.Contains(5))
        //                {
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[1]))); // NEW LAYOUT
        //                }
        //                else
        //                {
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Range(t => t.Field(f => f.QtyBedrooms).GreaterThanOrEquals(5))); // NEW LAYOUT
        //                }
        //            }
        //            else if (realty.QtyBedroomsList.Count == 3)
        //            {
        //                if (!realty.QtyBedroomsList.Contains(5))
        //                {
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[2]))); // NEW LAYOUT

        //                }
        //                else
        //                {
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Range(t => t.Field(f => f.QtyBedrooms).GreaterThanOrEquals(5))); // NEW LAYOUT
        //                }
        //            }
        //            else if (realty.QtyBedroomsList.Count == 4)
        //            {
        //                if (!realty.QtyBedroomsList.Contains(5))
        //                {
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[3])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[3]))); // NEW LAYOUT

        //                }
        //                else
        //                {
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[3])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[3])) ||
        //                                      fq.Range(t => t.Field(f => f.QtyBedrooms).GreaterThanOrEquals(5))); // NEW LAYOUT
        //                }
        //            }
        //            else if (realty.QtyBedroomsList.Count == 5)
        //            {
        //                if (!realty.QtyBedroomsList.Contains(5))
        //                {
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[3])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[3])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[4])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[4]))); // NEW LAYOUT

        //                }
        //                else
        //                {
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[1])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[2])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[3])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[3])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedrooms).Terms(realty.QtyBedroomsList[4])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtyBedroomsMax).Terms(realty.QtyBedroomsList[4])) ||
        //                                      fq.Range(t => t.Field(f => f.QtyBedrooms).GreaterThanOrEquals(5))); // NEW LAYOUT
        //                }
        //            }
        //        }

        //        if (realty.QtySuitesList != null && realty.QtySuitesList.Any())
        //        {
        //            if (realty.QtySuitesList.Count == 1)
        //            {
        //                if (realty.QtySuitesList[0] <= 4)
        //                    filters.Add(fq => fq.Terms(t => t.Field(f => f.QtySuites).Terms(realty.QtySuitesList[0])) ||
        //                                      fq.Terms(t => t.Field(f => f.QtySuitesMax).Terms(realty.QtySuitesList[0]))); // NEW LAYOUT 
        //                else
        //                    filters.Add(fq => fq.Range(t => t.Field(f => f.QtyBedrooms).GreaterThanOrEquals(5)));
        //            }
        //            //else if (r.QtySuitesList.Count == 2)
        //            //{
        //            //    if (!r.QtySuitesList.Contains(5))
        //            //    {
        //            //        predicateItem = predicateItem
        //            //            .And(a => a.QtySuites == r.QtySuitesList[0] || a.QtySuitesMax == r.QtySuitesList[0] || a.QtySuites == r.QtySuitesList[1] || a.QtySuitesMax == r.QtySuitesList[1]); // NEW LAYOUT
        //            //    }
        //            //    else
        //            //    {
        //            //        predicateItem = predicateItem
        //            //           .And(a => a.QtySuites == r.QtySuitesList[0] || a.QtySuitesMax == r.QtySuitesList[0] || a.QtySuites == r.QtySuitesList[1] || a.QtySuitesMax == r.QtySuitesList[1] || a.QtySuites >= 5); // NEW LAYOUT
        //            //    }
        //            //}
        //            //else if (r.QtySuitesList.Count == 3)
        //            //{
        //            //    if (!r.QtySuitesList.Contains(5))
        //            //    {
        //            //        predicateItem = predicateItem
        //            //            .And(a => a.QtySuites == r.QtySuitesList[0] || a.QtySuitesMax == r.QtySuitesList[0] || a.QtySuites == r.QtySuitesList[1] || a.QtySuitesMax == r.QtySuitesList[1] || a.QtySuites == r.QtySuitesList[2] || a.QtySuitesMax == r.QtySuitesList[2]); // NEW LAYOUT
        //            //    }
        //            //    else
        //            //    {
        //            //        predicateItem = predicateItem
        //            //           .And(a => a.QtySuites == r.QtySuitesList[0] || a.QtySuitesMax == r.QtySuitesList[0] || a.QtySuites == r.QtySuitesList[1] || a.QtySuitesMax == r.QtySuitesList[1] || a.QtySuites == r.QtySuitesList[2] || a.QtySuitesMax == r.QtySuitesList[2] || a.QtySuites >= 5); // NEW LAYOUT
        //            //    }
        //            //}
        //            //else if (r.QtySuitesList.Count == 4)
        //            //{
        //            //    if (!r.QtySuitesList.Contains(5))
        //            //    {
        //            //        predicateItem = predicateItem
        //            //            .And(a => a.QtySuites == r.QtySuitesList[0] || a.QtySuitesMax == r.QtySuitesList[0] || a.QtySuites == r.QtySuitesList[1] || a.QtySuitesMax == r.QtySuitesList[1] || a.QtySuites == r.QtySuitesList[2] || a.QtySuitesMax == r.QtySuitesList[2] || a.QtySuites == r.QtySuitesList[3] || a.QtySuitesMax == r.QtySuitesList[3]); // NEW LAYOUT
        //            //    }
        //            //    else
        //            //    {
        //            //        predicateItem = predicateItem
        //            //           .And(a => a.QtySuites == r.QtySuitesList[0] || a.QtySuitesMax == r.QtySuitesList[0] || a.QtySuites == r.QtySuitesList[1] || a.QtySuitesMax == r.QtySuitesList[1] || a.QtySuites == r.QtySuitesList[2] || a.QtySuitesMax == r.QtySuitesList[2] || a.QtySuites == r.QtySuitesList[3] || a.QtySuitesMax == r.QtySuitesList[3] || a.QtySuites >= 5); // NEW LAYOUT
        //            //    }
        //            //}
        //            //else if (r.QtySuitesList.Count == 5)
        //            //{
        //            //    if (!r.QtySuitesList.Contains(5))
        //            //    {
        //            //        predicateItem = predicateItem
        //            //            .And(a => a.QtySuites == r.QtySuitesList[0] || a.QtySuitesMax == r.QtySuitesList[0] || a.QtySuites == r.QtySuitesList[1] || a.QtySuitesMax == r.QtySuitesList[1] || a.QtySuites == r.QtySuitesList[2] || a.QtySuitesMax == r.QtySuitesList[2] || a.QtySuites == r.QtySuitesList[3] || a.QtySuitesMax == r.QtySuitesList[3] || a.QtySuites == r.QtySuitesList[4] || a.QtySuitesMax == r.QtySuitesList[4]); // NEW LAYOUT
        //            //    }
        //            //    else
        //            //    {
        //            //        predicateItem = predicateItem
        //            //           .And(a => a.QtySuites == r.QtySuitesList[0] || a.QtySuitesMax == r.QtySuitesList[0] || a.QtySuites == r.QtySuitesList[1] || a.QtySuitesMax == r.QtySuitesList[1] || a.QtySuites == r.QtySuitesList[2] || a.QtySuitesMax == r.QtySuitesList[2] || a.QtySuites == r.QtySuitesList[3] || a.QtySuitesMax == r.QtySuitesList[3] || a.QtySuites == r.QtySuitesList[4] || a.QtySuitesMax == r.QtySuitesList[4] || a.QtySuites >= 5); // NEW LAYOUT
        //            //    }
        //            //}

        //        }

        //        //if (r.QtyDemarkedVacanciesList != null && r.QtyDemarkedVacanciesList.Any())
        //        //{
        //        //    if (r.QtyDemarkedVacanciesList.Count == 1)
        //        //    {
        //        //        if (r.QtyDemarkedVacanciesList[0] <= 4)
        //        //        {
        //        //            predicateItem = predicateItem
        //        //                .And(a => a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[0]);
        //        //        }
        //        //        else
        //        //        {
        //        //            predicateItem = predicateItem
        //        //                .And(a => a.QtyDemarkedVacancies >= 5);
        //        //        }
        //        //    }
        //        //    else if (r.QtyDemarkedVacanciesList.Count == 2)
        //        //    {
        //        //        if (!r.QtyDemarkedVacanciesList.Contains(5))
        //        //        {
        //        //            predicateItem = predicateItem
        //        //                .And(a => a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[1]);
        //        //        }
        //        //        else
        //        //        {
        //        //            predicateItem = predicateItem
        //        //               .And(a => a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacancies >= 5);
        //        //        }
        //        //    }
        //        //    else if (r.QtyDemarkedVacanciesList.Count == 3)
        //        //    {
        //        //        if (!r.QtyDemarkedVacanciesList.Contains(5))
        //        //        {
        //        //            predicateItem = predicateItem
        //        //                .And(a => a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[2]);
        //        //        }
        //        //        else
        //        //        {
        //        //            predicateItem = predicateItem
        //        //               .And(a => a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacancies >= 5);
        //        //        }
        //        //    }
        //        //    else if (r.QtyDemarkedVacanciesList.Count == 4)
        //        //    {
        //        //        if (!r.QtyDemarkedVacanciesList.Contains(5))
        //        //        {
        //        //            predicateItem = predicateItem
        //        //                .And(a => a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[3] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[3]);
        //        //        }
        //        //        else
        //        //        {
        //        //            predicateItem = predicateItem
        //        //               .And(a => a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[3] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[3] || a.QtyDemarkedVacancies >= 5);
        //        //        }
        //        //    }
        //        //    else if (r.QtyDemarkedVacanciesList.Count == 5)
        //        //    {
        //        //        if (!r.QtyDemarkedVacanciesList.Contains(5))
        //        //        {
        //        //            predicateItem = predicateItem
        //        //                .And(a => a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[3] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[3] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[4] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[4]);
        //        //        }
        //        //        else
        //        //        {
        //        //            predicateItem = predicateItem
        //        //               .And(a => a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[0] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[1] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[2] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[3] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[3] || a.QtyDemarkedVacancies == r.QtyDemarkedVacanciesList[4] || a.QtyDemarkedVacanciesMax == r.QtyDemarkedVacanciesList[4] || a.QtyDemarkedVacancies >= 5);
        //        //        }
        //        //    }
        //        //}
        //        ////Apenas imoveis com mais de 2 fotos devem retornar na busca
        //        //predicateItem = predicateItem.And(a => a.QtyRealtyMultimedia > 2); // NEW LAYOUT

        //        ////price
        //        //var price = false;
        //        //var priceHigh = decimal.MaxValue;
        //        //var priceLow = (decimal)0;
        //        //if (r.MarketingTypeId != 3)
        //        //{
        //        //    if (r.PriceHigh.HasValue && r.PriceHigh.Value > 0)
        //        //    {
        //        //        priceHigh = r.PriceHigh.Value;
        //        //        price = true;
        //        //    }
        //        //    if (r.PriceLow.HasValue && r.PriceLow.Value > 0)
        //        //    {
        //        //        priceLow = r.PriceLow.Value;
        //        //        price = true;
        //        //    }
        //        //}

        //        ////monthlyRent
        //        //var monthlyRent = false;
        //        //var monthRentHigh = decimal.MaxValue;
        //        //var monthRentLow = (decimal)0;
        //        //if (r.MarketingTypeId == 3)
        //        //{
        //        //    if (r.MonthlyRentHigh.HasValue && r.MonthlyRentHigh.Value > 0)
        //        //    {
        //        //        monthRentHigh = r.MonthlyRentHigh.Value;
        //        //        monthlyRent = true;
        //        //    }
        //        //    if (r.MonthlyRentLow.HasValue && r.MonthlyRentLow.Value > 0)
        //        //    {
        //        //        monthRentLow = r.MonthlyRentLow.Value;
        //        //        monthlyRent = true;
        //        //    }
        //        //}

        //        ////privateArea
        //        //var privateArea = false;
        //        //var privateAreaHigh = decimal.MaxValue;
        //        //var privateAreaLow = (decimal)0;
        //        //if (r.PrivateAreaHigh.HasValue && r.PrivateAreaHigh.Value > 0)
        //        //{
        //        //    privateAreaHigh = r.PrivateAreaHigh.Value;
        //        //    privateArea = true;
        //        //}
        //        //if (r.PrivateAreaLow.HasValue && r.PrivateAreaLow > 0)
        //        //{
        //        //    privateAreaLow = r.PrivateAreaLow.Value;
        //        //    privateArea = true;
        //        //}

        //        //if (price)
        //        //{
        //        //    if (!hasOwner)
        //        //    {
        //        //        predicateItem = predicateItem.And(
        //        //            a => a.BestPrice >= priceLow && a.BestPrice <= priceHigh);
        //        //    }
        //        //    else
        //        //    {
        //        //        predicateItem = predicateItem.And(
        //        //            a => a.RealtyDivisions.Any(
        //        //                rd => rd.DesignUnits.Any(
        //        //                    du => du.Price >= priceLow && du.Price <= priceHigh)));

        //        //    }
        //        //}



        //        //if (monthlyRent)
        //        //{
        //        //    if (!hasOwner)
        //        //    {
        //        //        predicateItem = predicateItem.And(
        //        //            a => a.BestRent >= priceLow && a.BestRent <= priceHigh);
        //        //    }
        //        //    else
        //        //    {
        //        //        predicateItem = predicateItem.And(
        //        //            // a=> a.BestRent >= priceLow && a.BestRent <= priceHigh);
        //        //            a => a.RealtyDivisions.Any(
        //        //                rd => rd.DesignUnits.Any(
        //        //                    du => du.MonthlyRent >= monthRentLow && du.MonthlyRent <= monthRentHigh)));
        //        //    }
        //        //}
        //        //if (privateArea)
        //        //{
        //        //    predicateItem = predicateItem.And(
        //        //        // a => a.PrivateArea >= privateAreaLow && a.PrivateArea <= privateAreaHigh);
        //        //        a => a.RealtyDivisions.Any(
        //        //            rd => rd.DesignUnits.Any(
        //        //                du => du.PrivateArea >= privateAreaLow && du.PrivateArea <= privateAreaHigh)));
        //        //}

        //        //predicate = predicate.Or(predicateItem);
        //    }

        //    var response = await elasticClient.SearchAsync<Realties>(x => x.Index(indexName)
        //                                      .Query(q => q.Bool(bq => bq.Filter(filters))));

        //    return (response.Documents.ToList(), marketingTypeId);
        //}

        private List<int> DeterminaIdCategories(string[] categories)
        {
            List<int> idCategories = new List<int>();
            foreach (var item in categories)
            {
                switch (item.ToUpperInvariant())
                {

                    case "APARTAMENTO":
                        idCategories.AddRange(new List<int> { 6, 7, 8, 9, 10, 11, 26, 27, 28, 29, 30, 31, 56 });
                        break;
                    case "AREA DE TERRA":
                        idCategories.AddRange(new List<int> { 17, 49, 50 });
                        break;
                    case "BARRACÃO":
                        idCategories.AddRange(new List<int> { 25, 43, 58 });
                        break;
                    case "CASA":
                        idCategories.AddRange(new List<int> { 1, 2, 3, 4, 5, 32, 33, 34, 35, 36, 37, 38, 39, 40, 59, 60, 61 });
                        break;
                    case "CASA DE-VILA":
                        idCategories.Add(40);
                        break;
                    case "CASA TERREA":
                        idCategories.Add(5);
                        break;
                    case "CHACARA":
                        idCategories.Add(52);
                        break;
                    case "COBERTURA":
                        idCategories.AddRange(new List<int> { 1, 8, 19, 26, 31 });
                        break;
                    case "CONDOMINIO FECHADO":
                        idCategories.AddRange(new List<int> { 39, 48, 61 });
                        break;
                    case "DUPLEX/TRIPLEX":
                        idCategories.AddRange(new List<int> { 9, 11, 26, 31, 14, 16, 23, 24 });
                        break;
                    case "FAZENDA/CHACARA_SITIO":
                        idCategories.AddRange(new List<int> { 51, 52, 53 });
                        break;
                    case "FLAT":
                        idCategories.Add(28);
                        break;
                    case "GALPÃO/BARRAÇÃO":
                        idCategories.AddRange(new List<int> { 43, 25, 58 });
                        break;
                    case "HOTEL":
                        idCategories.AddRange(new List<int> { 19, 20, 21, 22, 23, 24, 55 });
                        break;
                    case "LAJES":
                        idCategories.Add(42);
                        break;
                    case "LOFT":
                        idCategories.Add(30);
                        break;
                    case "LOJA":
                        idCategories.Add(44);
                        break;
                    case "LOTEAMENTO":
                        idCategories.AddRange(new List<int> { 17, 50 });
                        break;
                    case "PREDIO INTEIRO":
                        idCategories.Add(47);
                        break;
                    case "SALAO COMERCIAL":
                        idCategories.Add(46);
                        break;
                    case "SALAS":
                        idCategories.Add(46);
                        break;
                    case "SITIO":
                        idCategories.Add(51);
                        break;
                    case "SOBRADO":
                        idCategories.AddRange(new List<int> { 4, 32, 33, 60 });
                        break;
                    case "STUDIO":
                        idCategories.AddRange(new List<int> { 27, 56 });
                        break;
                    case "LOTE/TERRENO":
                        idCategories.AddRange(new List<int> { 17, 50, 49 });
                        break;
                    case "TRIPLEX":
                        idCategories.AddRange(new List<int> { 11, 16, 24, 31 });
                        break;
                    case "VILLAGIO":
                        idCategories.Add(61);
                        break;
                    default:
                        break;
                }
            }

            return idCategories;
        }

    }
}

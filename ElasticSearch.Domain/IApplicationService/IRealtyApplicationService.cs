using ElasticSearch.Domain.Classes;
using System.Threading.Tasks;

namespace ElasticSearch.Domain.IApplicationService
{
    public interface IRealtyApplicationService
    {
        Task<PagedResult<Realties>> GetbyAttrib(PagedRealtyFilter realtyFilter);
        Task ReIndex();
    }
}

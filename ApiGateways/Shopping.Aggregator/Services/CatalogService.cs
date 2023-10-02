using Shopping.Aggregator.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        public Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogModel> GetCatalog(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            throw new System.NotImplementedException();
        }
    }
}

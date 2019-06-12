using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_showcase.Domain.DataAccess
{
    public interface ICatalogRepository
    {
        Task<Catalog> GetCatalogById(Guid id);
        Task<IEnumerable<Catalog>> GetAllCatalogs();
    }

    public class InMemoryCatalogRepository : ICatalogRepository
    {
        List<Catalog> Catalogs { get; }
            = new List<Catalog>();

        public async Task<IEnumerable<Catalog>> GetAllCatalogs()
        {
            return Catalogs;
        }

        public async Task<Catalog> GetCatalogById(Guid id)
        {
            return Catalogs.Single(catalog => catalog.ID == id);
        }
    }
}

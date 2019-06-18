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

        Task<Catalog> CreateCatalog(string name);
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

        public async Task<Catalog> CreateCatalog(string name)
        {
            var newCatalog = new Catalog()
            {
                ID = Guid.NewGuid(),
                Name = name
            };

            Catalogs.Add(newCatalog);

            return newCatalog;
        }
    }
}

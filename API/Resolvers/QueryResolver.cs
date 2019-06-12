using graphql_showcase.Domain.DataAccess;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace graphql_showcase.API.Resolvers
{
    public class QueryResolver
    {
        public async Task<IEnumerable<Domain.Product>> GetProducts([Service] IProductRepository repository)
        {
            return await repository.GetAllProducts();
        }

        public async Task<Domain.Product> GetProductById(Guid id, [Service] IProductRepository repository)
        {
            return await repository.GetProductById(id);
        }

        public Domain.Catalog GetCatalog()
        {
            return new Domain.Catalog()
            {
                ID = Guid.NewGuid(),
                Name = "Example collection"
            };
        }
    }
}

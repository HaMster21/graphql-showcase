using graphql_showcase.Domain.DataAccess;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace graphql_showcase.API.Resolvers
{
    public class QueryResolver
    {
        [GraphQLName("products")]
        [GraphQLDescription("Return a list of all known products")]
        public async Task<IEnumerable<Domain.Product>> GetProducts([Service] IProductRepository repository)
        {
            return await repository.GetAllProducts();
        }

        [GraphQLName("product")]
        [GraphQLDescription("Look up a product by its ID")]
        public async Task<Domain.Product> GetProductById(Guid id, [Service] IProductRepository repository)
        {
            return await repository.GetProductById(id);
        }

        [GraphQLName("catalogs")]
        [GraphQLDescription("Return a list of all known catalogs")]
        public async Task<IEnumerable<Domain.Catalog>> GetCatalogs([Service] ICatalogRepository repository)
        {
            return await repository.GetAllCatalogs();
        }

        [GraphQLName("catalog")]
        [GraphQLDescription("Look up a catalog by its ID")]
        public async Task<Domain.Catalog> GetCatalogById(Guid id, [Service] ICatalogRepository repository)
        {
            return await repository.GetCatalogById(id);
        }
    }
}

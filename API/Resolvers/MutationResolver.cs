using HotChocolate;
using System;
using System.Threading.Tasks;

namespace graphql_showcase.API.Resolvers
{
    public class MutationResolver
    {
        [GraphQLDescription("Create a new product")]
        public async Task<Domain.Product> CreateProduct([GraphQLNonNullType] Types.CreateProductInput input,
                                                        [Service] Domain.DataAccess.IProductRepository repository)
        {
            return await repository.CreateProduct(input.ProductName, input.GTIN);
        }

        [GraphQLDescription("Delete a product")]
        public async Task<Domain.Product> DeleteProduct([GraphQLNonNullType] Guid id,
                                                        [Service] Domain.DataAccess.IProductRepository repository)
        {
            return await repository.DeleteProduct(id);
        }

        public async Task<Domain.Product> UpdateProduct([GraphQLNonNullType] Guid id,
                                                        [GraphQLNonNullType] Types.UpdateProductInput input,
                                                        [Service] Domain.DataAccess.IProductRepository repository)
        {
            return await repository.UpdateProduct(id, input.Name, input.GTIN);
        }

        public async Task<Domain.Catalog> CreateCatalog([GraphQLNonNullType] Types.CreateCatalogInput input,
                                                        [Service] Domain.DataAccess.ICatalogRepository repository)
        {
            return await repository.CreateCatalog(input.CatalogName);
        }

        public async Task<Domain.Catalog> DeleteCatalog([GraphQLNonNullType] Guid id,
                                                        [Service] Domain.DataAccess.ICatalogRepository repository)
        {
            return await repository.DeleteCatalog(id);
        }
    }
}

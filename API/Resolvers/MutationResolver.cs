using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Domain.Product> DeleteProduct([GraphQLNonNullType] Guid id,
                                                        [Service] Domain.DataAccess.IProductRepository repository)
        {
            return await repository.DeleteProduct(id);
        }
    }
}

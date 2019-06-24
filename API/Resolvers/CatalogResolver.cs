using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_showcase.API.Resolvers
{
    public class CatalogResolver
    {
        public async Task<IList<Domain.Product>> Products([Parent] Domain.Catalog catalog,
                                                          [Service] Domain.DataAccess.IProductRepository productRepository)
        {
            var products = new List<Domain.Product>();

            foreach (var productID in catalog.Products)
            {
                var referencedProduct = await productRepository.GetProductById(productID);
                products.Add(referencedProduct);
            }

            return products;
        }
    }
}

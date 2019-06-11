using HotChocolate;
using HotChocolate.Types;
using System;

namespace graphql_showcase.API.Resolvers
{
    public class ProductResolver
    {
        [GraphQLName("id")]
        [GraphQLType(typeof(IdType))]
        [GraphQLDescription("Unique identifier of a product")]
        public Guid ID([Parent] Domain.Product product)
        {
            return product.ID;
        }

        [GraphQLDescription("Name of the product as given by the manufacturer")]
        public string Name([Parent] Domain.Product product)
        {
            return product.Name;
        }

        [GraphQLName("GTIN")]
        [GraphQLDescription("Global trade item number of the product")]
        public long GTIN([Parent] Domain.Product product)
        {
            return product.GTIN;
        }
    }
}

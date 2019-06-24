using System;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_showcase.Domain
{
    [GraphQLName("product")]
    [GraphQLDescription("A product for a webshop")]
    public class Product
    {
        [GraphQLName("id")]
        [GraphQLDescription("Unique identifier of a product")]
        [GraphQLType(typeof(NonNullType<IdType>))]
        public Guid ID { get; set; }

        [GraphQLName("name")]
        [GraphQLDescription("the name of this product")]
        [GraphQLNonNullType]
        public string Name { get; set; }

        [GraphQLName("GTIN")]
        [GraphQLDescription("Global trade item number of the product")]
        public long GTIN { get; set; }
    }
}

using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_showcase.Domain
{
    [GraphQLName("catalog")]
    [GraphQLDescription("A named collection of products")]
    public class Catalog
    {
        // [GraphQLName("id")]
        // [GraphQLDescription("Unique identifier of a catalog")]
        // [GraphQLType(typeof(NonNullType<IdType>))]
        public Guid ID { get; set; }
        
        [GraphQLName("name")]
        [GraphQLDescription("the name of this product collection")]
        [GraphQLNonNullType]
        public string Name { get; set; }

        [GraphQLNonNullType]
        public IList<Guid> Products { get; } = new List<Guid>();
    }
}

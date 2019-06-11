using HotChocolate;
using HotChocolate.Types;
using System;

namespace graphql_showcase.API.Resolvers
{
    public class CatalogResolver
    {
        [GraphQLName("id")]
        [GraphQLType(typeof(IdType))]
        [GraphQLDescription("Unique identifier of a catalog")]
        public Guid ID([Parent] Domain.Catalog catalog)
        {
            return catalog.ID;
        }

        [GraphQLDescription("The name of the product collection")]
        public string Name([Parent] Domain.Catalog catalog)
        {
            return catalog.Name;
        }
    }
}

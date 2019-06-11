using graphql_showcase.Domain;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_showcase.API.Types
{
    public class CatalogType : ObjectType<Domain.Catalog>
    {
        protected override void Configure(IObjectTypeDescriptor<Catalog> descriptor)
        {
            descriptor.Name("Catalog");
            descriptor.Description("A named collection of products");

            descriptor.BindFields(BindingBehavior.Explicit);
            descriptor.Include<API.Resolvers.CatalogResolver>();
        }
    }
}

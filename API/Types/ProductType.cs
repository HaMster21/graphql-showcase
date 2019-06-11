using graphql_showcase.Domain;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_showcase.API.Types
{
    public class ProductType : ObjectType<Domain.Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Name("Product");
            descriptor.Description("A product for a webshop");
            descriptor.BindFields(BindingBehavior.Explicit);
            descriptor.Include<Resolvers.ProductResolver>();
        }
    }
}

using graphql_showcase.Domain;
using HotChocolate;
using HotChocolate.Types;
using System;

namespace graphql_showcase.API.Types
{
    public class ProductType : ObjectType<Domain.Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Name("Product");
            descriptor.Description("A product for a webshop");
            descriptor.BindFields(BindingBehavior.Explicit);

            descriptor.Field(t => t.ID)
                      .Name("id")
                      .Description("Unique identifier of a product")
                      .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Name)
                      .Name("name")
                      .Description("name of the product")
                      .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.GTIN)
                      .Name("GTIN")
                      .Description("global trade item number of the product");

            descriptor.AsNode()
                      .IdField(t => t.ID)
                      .NodeResolver((ctx, id) => ctx.Service<Domain.DataAccess.IProductRepository>().GetProductById((Guid) id));
        }
    }
}

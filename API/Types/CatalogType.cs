using HotChocolate;
using HotChocolate.Types;

namespace graphql_showcase.API.Types
{
    public class CatalogType :
        ObjectType<Domain.Catalog>
    {
        protected override void Configure(IObjectTypeDescriptor<Domain.Catalog> descriptor)
        {
            descriptor.Field(t => t.Products)
                      .Type<NonNullType<ListType<NonNullType<ProductType>>>>();

            descriptor.Field(t => t.ID)
                      .Name("id")
                      .Description("bla")
                      .Type<NonNullType<IdType>>();

            descriptor.AsNode()
                      .IdField(t => t.ID)
                      .NodeResolver((ctx, id)
                        => ctx.Service<Domain.DataAccess.ICatalogRepository>().GetCatalogById(id));
        }
    }
}

using graphql_showcase.Domain;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_showcase.API.Types
{
    public class CatalogType : ObjectType<Domain.Catalog>
    {
        protected override void Configure(IObjectTypeDescriptor<Catalog> descriptor)
        {
            descriptor.Name("Catalog");
            descriptor.Description("A named collection of products");
            descriptor.BindFields(BindingBehavior.Explicit);

            descriptor.Field(t => t.ID)
                      .Name("id")
                      .Description("Unique identitfier of a catalog")
                      .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Name)
                      .Name("name")
                      .Description("the catalogs name");

            descriptor.Include<Resolvers.CatalogResolver>();

            descriptor.AsNode()
                      .IdField(t => t.ID)
                      .NodeResolver((ctx, id) => ctx.Service<Domain.DataAccess.ICatalogRepository>()
                                                    .GetCatalogById(id));
        }
    }
}

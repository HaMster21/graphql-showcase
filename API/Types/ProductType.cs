using HotChocolate;
using HotChocolate.Types;

namespace graphql_showcase.API.Types
{
    public class ProductType :
        ObjectType<Domain.Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Domain.Product> descriptor)
        {
            descriptor.AsNode()
                      .IdField(t => t.ID)
                      .NodeResolver((ctx, id)
                        => ctx.Service<Domain.DataAccess.IProductRepository>().GetProductById(id));
        }
    }
}

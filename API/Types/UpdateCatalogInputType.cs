using HotChocolate;
using HotChocolate.Types;

namespace graphql_showcase.API.Types
{
    public class UpdateCatalogInput
    {
        [GraphQLNonNullType]
        [GraphQLDescription("the new name of the catalog")]
        public string Name { get; set; }
    }

    public class UpdateCatalogInputType : InputObjectType<UpdateCatalogInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateCatalogInput> descriptor)
        {
            descriptor.Name("UpdateCatalogInput");
        }
    }
}

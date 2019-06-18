using HotChocolate;
using HotChocolate.Types;

namespace graphql_showcase.API.Types
{
    public class CreateCatalogInput
    {
        [GraphQLName("name")]
        [GraphQLDescription("the name of the new catalog")]
        [GraphQLNonNullType]
        public string CatalogName { get; set; }
    }

    public class CreateCatalogInputType : InputObjectType<CreateCatalogInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateCatalogInput> descriptor)
        {
            descriptor.Name("CreateCatalogInput");
        }
    }
}

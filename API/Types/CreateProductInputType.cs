using HotChocolate;
using HotChocolate.Types;

namespace graphql_showcase.API.Types
{
    public class CreateProductInput
    {
        [GraphQLName("name")]
        [GraphQLDescription("the name of the new product")]
        [GraphQLNonNullType]
        public string ProductName { get; set; }

        [GraphQLName("GTIN")]
        [GraphQLDescription("the global trade item number of the new product")]
        [GraphQLNonNullType]
        public long GTIN { get; set; }
    }

    public class CreateProductInputType : InputObjectType<CreateProductInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateProductInput> descriptor)
        {
            descriptor.Name("CreateProductInput");
        }
    }
}

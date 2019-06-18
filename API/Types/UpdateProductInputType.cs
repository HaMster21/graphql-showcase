using HotChocolate;
using HotChocolate.Types;

namespace graphql_showcase.API.Types
{
    public class UpdateProductInput
    {
        [GraphQLNonNullType]
        [GraphQLDescription("the new name of the product")]
        public string Name { get; set; }

        [GraphQLName("GTIN")]
        [GraphQLNonNullType]
        [GraphQLDescription("the new global trade item number of the product")]
        public long GTIN { get; set; }
    }

    public class UpdateProductInputType : InputObjectType<UpdateProductInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateProductInput> descriptor)
        {
            descriptor.Name("UpdateProductInput");
        }
    }
}

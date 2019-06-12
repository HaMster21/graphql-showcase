using graphql_showcase.API.Resolvers;
using HotChocolate.Types;

namespace graphql_showcase.API.Types
{
    public class Mutation { }

    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Name("Mutation");
            descriptor.BindFields(BindingBehavior.Explicit);
            descriptor.Include<MutationResolver>();
        }
    }
}

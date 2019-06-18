using HotChocolate.Types;

namespace graphql_showcase.API.Types
{
    public class Query
    {
    }

    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Name("Query");
            descriptor.Description("Provides access to queries");

            descriptor.BindFields(BindingBehavior.Explicit);
            descriptor.Include<Resolvers.QueryResolver>();
        }
    }
}
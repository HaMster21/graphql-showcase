using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace graphql_showcase
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInMemorySubscriptionProvider();

            // this enables you to use DataLoader in your resolvers.
            services.AddDataLoaderRegistry();

            // Add GraphQL Services
            services.AddGraphQL(sp => SchemaBuilder.New()
                // enable for authorization support
                // .AddDirectiveType<AuthorizeDirectiveType>()
                .AddQueryType<Query>()
                .Create());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseGraphiQL();
            }

            app.UseWebSockets();
            app.UseGraphQL();
        }
    }
}

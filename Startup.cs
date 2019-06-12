using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace graphql_showcase
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Domain.DataAccess.IProductRepository, Domain.DataAccess.InMemoryProductRepository>();
            services.AddSingleton<Domain.DataAccess.ICatalogRepository, Domain.DataAccess.InMemoryCatalogRepository>();

            services.AddInMemorySubscriptionProvider();

            // this enables you to use DataLoader in your resolvers.
            services.AddDataLoaderRegistry();

            // Add GraphQL Services
            services.AddGraphQL(sp
                => SchemaBuilder.New()
                // enable for authorization support
                // .AddDirectiveType<AuthorizeDirectiveType>()

                .AddQueryType<API.Types.QueryType>()
                .AddMutationType<API.Types.MutationType>()

                .AddType<API.Types.ProductType>()
                .AddType<API.Types.CatalogType>()

                .AddType<API.Types.CreateProductInputType>()

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

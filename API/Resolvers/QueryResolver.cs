using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_showcase.API.Resolvers
{
    public class QueryResolver
    {
        public Domain.Product GetProduct()
        {
            return new Domain.Product()
            {
                ID = Guid.NewGuid(),
                Name = "Fanta Cucumber",
                GTIN = 42
            };
        }

        public Domain.Catalog GetCatalog()
        {
            return new Domain.Catalog()
            {
                ID = Guid.NewGuid(),
                Name = "Example collection"
            };
        }
    }
}

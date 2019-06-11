using System;

namespace graphql_showcase.Domain
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public long GTIN { get; set; }
    }
}

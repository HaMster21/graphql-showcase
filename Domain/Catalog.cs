using System;
using System.Collections.Generic;

namespace graphql_showcase.Domain
{
    public class Catalog
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public IList<Guid> Products { get; } = new List<Guid>();
    }
}

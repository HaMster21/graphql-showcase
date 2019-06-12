using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_showcase.Domain.DataAccess
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(Guid id);

        Task<IEnumerable<Product>> GetAllProducts();
    }

    public class InMemoryProductRepository : IProductRepository
    {
        private List<Product> Products { get; }
            = new List<Product>()
            {
                new Product() { ID = Guid.NewGuid(), Name = "Fanta Cucumber", GTIN = 42 }
            };

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return Products;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return Products.Single(p => p.ID == id);
        }
    }
}

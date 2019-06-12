using graphql_showcase.API.Types;
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

        Task<Product> CreateProduct(string name, long gtin);

        Task<Product> UpdateProduct(Guid id, string name, long gtin);

        Task<Product> DeleteProduct(Guid id);
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
            return Products.Single(product => product.ID == id);
        }

        public async Task<Product> CreateProduct(string name, long gtin)
        {
            var newProduct = new Product()
            {
                ID = Guid.NewGuid(),
                Name = name ?? throw new ArgumentNullException(nameof(name)),
                GTIN = gtin
            };

            Products.Add(newProduct);

            return newProduct;
        }

        public async Task<Product> DeleteProduct(Guid id)
        {
            var productToDelete = Products.Single(product => product.ID == id);

            Products.Remove(productToDelete);

            return productToDelete;
        }

        public async Task<Product> UpdateProduct(Guid id, string name, long gtin)
        {
            var productToUpdate = Products.Single(product => product.ID == id);

            productToUpdate.Name = name;
            productToUpdate.GTIN = gtin;

            return productToUpdate;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_showcase.Domain.DataAccess
{
    public interface ICatalogRepository
    {
        Task<Catalog> GetCatalogById(Guid id);
        Task<IEnumerable<Catalog>> GetAllCatalogs();

        Task<Catalog> CreateCatalog(string name);

        Task<Catalog> DeleteCatalog(Guid id);

        Task<Catalog> UpdateCatalog(Guid id, string name);

        Task<Catalog> AddProduct(Guid catalogID, Guid productID);

        Task<Catalog> RemoveProduct(Guid catalogID, Guid productID);
    }

    public class InMemoryCatalogRepository : ICatalogRepository
    {
        List<Catalog> Catalogs { get; }
            = new List<Catalog>();

        public async Task<IEnumerable<Catalog>> GetAllCatalogs()
        {
            return Catalogs;
        }

        public async Task<Catalog> GetCatalogById(Guid id)
        {
            return Catalogs.Single(catalog => catalog.ID == id);
        }

        public async Task<Catalog> CreateCatalog(string name)
        {
            var newCatalog = new Catalog()
            {
                ID = Guid.NewGuid(),
                Name = name
            };

            Catalogs.Add(newCatalog);

            return newCatalog;
        }

        public async Task<Catalog> DeleteCatalog(Guid id)
        {
            var catalogToDelete = Catalogs.Single(catalog => catalog.ID == id);
            Catalogs.Remove(catalogToDelete);
            return catalogToDelete;
        }

        public async Task<Catalog> UpdateCatalog(Guid id, string name)
        {
            var catalogToChange = Catalogs.Single(catalog => catalog.ID == id);
            catalogToChange.Name = name;
            return catalogToChange;
        }

        public async Task<Catalog> AddProduct(Guid catalogID, Guid productID)
        {
            var referencedCatalog = Catalogs.Single(catalog => catalog.ID == catalogID);

            referencedCatalog.Products.Add(productID);

            return referencedCatalog;
        }

        public async Task<Catalog> RemoveProduct(Guid catalogID, Guid productID)
        {
            var referencedCatalog = Catalogs.Single(catalog => catalog.ID == catalogID);

            referencedCatalog.Products.Remove(productID);

            return referencedCatalog;
        }
    }
}

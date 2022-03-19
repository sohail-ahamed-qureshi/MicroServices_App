using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetProductsById(string name)
        {
            FilterDefinition<Products> filter = Builders<Products>.Filter.Eq(p => p.Name, name);

            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetProductsByCategory(string category)
        {
            FilterDefinition<Products> filter = Builders<Products>.Filter.Eq(p => p.Category, category);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task CreateProduct(Products newProduct)
        {
            await _context.Products.InsertOneAsync(newProduct);

        }

        public async Task<bool> UpdateProduct(Products products)
        {
            var updated = await _context.Products.ReplaceOneAsync(filter: p => p.Id == products.Id, replacement: products);
            return updated.IsAcknowledged && updated.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Products> filter = Builders<Products>.Filter.Eq(p => p.Id, id);
            var deleted = await _context.Products.DeleteOneAsync(filter);
            return deleted.IsAcknowledged && deleted.DeletedCount > 0;

        }
    }
}

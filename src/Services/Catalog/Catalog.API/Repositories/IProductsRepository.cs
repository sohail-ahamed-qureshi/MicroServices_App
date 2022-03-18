using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<IEnumerable<Products>> GetProductsById(string name);
        Task<IEnumerable<Products>> GetProductsByCategory(string category);
        Task CreateProduct(Products newProduct);
        Task<bool> UpdateProduct(Products products);
        Task<bool> DeleteProduct(string id);
    }
}

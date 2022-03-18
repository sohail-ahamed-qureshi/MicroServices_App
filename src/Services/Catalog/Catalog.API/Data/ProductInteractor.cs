using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories;

namespace Catalog.API.Data
{
    public class ProductInteractor : IProductInteractor
    {
        private readonly IProductsRepository _productRepository;
        public ProductInteractor(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProduct(Products newProduct)
        {
            await _productRepository.CreateProduct(newProduct);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            return await _productRepository.DeleteProduct(id);
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<IEnumerable<Products>> GetProductsByCategory(string category)
        {
            return await _productRepository.GetProductsByCategory(category);
        }

        public async Task<IEnumerable<Products>> GetProductsByName(string name)
        {
            return await _productRepository.GetProductsById(name);
        }

        public async Task<bool> UpdateProduct(Products products)
        {
            return await _productRepository.UpdateProduct(products);
        }
    }
}

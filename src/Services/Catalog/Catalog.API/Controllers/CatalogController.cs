using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductInteractor _productInteractor;
        public CatalogController(IProductInteractor productInteractor)
        {
            _productInteractor = productInteractor;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsList = await _productInteractor.GetProducts();
            if (productsList.Count() > 0)
            {
                return Ok(productsList);
            }
            return Ok("No products to display");
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByCategory(string categoryName)
        {
            var productsList = await _productInteractor.GetProductsByCategory(categoryName);
            if (productsList.Count() > 0)
            {
                return Ok(productsList);
            }
            return Ok("No products to display");
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            var productsList = await _productInteractor.GetProductsByName(name);
            if (productsList.Count() > 0)
            {
                return Ok(productsList);
            }
            return Ok("No products to display");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Products product)
        {
            await _productInteractor.CreateProduct(product);
            return Ok("Product Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Products product)
        {
            var updated = await _productInteractor.UpdateProduct(product);
            if (updated)
            {
                return Ok("Product Updated");
            }
            return Ok("Product Update failed");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var deleted = await _productInteractor.DeleteProduct(id);
            if (deleted)
            {
                return Ok("Product deleted");
            }
            return Ok("Product delete failed");
        }
    }
}

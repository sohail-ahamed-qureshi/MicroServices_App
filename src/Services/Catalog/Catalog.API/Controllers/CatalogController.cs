using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
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
    }
}

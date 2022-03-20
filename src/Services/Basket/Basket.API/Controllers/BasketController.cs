using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.API.Data;
using Basket.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketInteractor _basketInteractor;

        public BasketController(IBasketInteractor basketInteractor)
        {
            _basketInteractor = basketInteractor;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket(string userName)
        {
            var basket = await _basketInteractor.GetBasket(userName);
            return Ok(basket ?? new ShoppingCart(userName)); ;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(ShoppingCart basket)
        {
            var basketList = await _basketInteractor.UpdateBasket(basket);
            return Ok(basketList);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _basketInteractor.DeleteBasket(userName);
            return Ok(userName);

        }
    }
}

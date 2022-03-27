using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.API.Data;
using Discount.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountInteractor _discountInteractor;

        public DiscountController(IDiscountInteractor discountInteractor)
        {
            _discountInteractor = discountInteractor;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscount(string productName)
        {
            var coupon = await _discountInteractor.GetDiscount(productName);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(Coupon coupon)
        {
            bool isCreated = await _discountInteractor.CreateDiscount(coupon);
            if (isCreated)
            {
                return Ok("coupon created");
            }
            return Ok("fail to create coupon");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(Coupon coupon)
        {
            var isUpdated = await _discountInteractor.UpdateDiscount(coupon);
            if (isUpdated)
            {
                return Ok("coupon is Updated");
            }
            return Ok("fail to update coupon");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscount(string productName)
        {
            var isDeleted = await _discountInteractor.DeleteDiscount(productName);
            if (isDeleted)
                return Ok("coupon is deleted");
            return Ok("fail to delete coupon");
        }
    }
}

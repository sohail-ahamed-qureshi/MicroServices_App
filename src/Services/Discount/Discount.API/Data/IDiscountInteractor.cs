using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.API.Entities;

namespace Discount.API.Data
{
    public interface IDiscountInteractor
    {

        Task<Coupon> GetDiscount(string productName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);
        Task<bool> UpdateDiscount(Coupon coupon);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.Grpc.Entities;
using Discount.Grpc.Repositories;

namespace Discount.Grpc.Data
{
    public class DiscountInteractor : IDiscountInteractor
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountInteractor(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            return await _discountRepository.CreateDiscount(coupon);
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            return await _discountRepository.DeleteDiscount(productName);
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            return await _discountRepository.GetDiscount(productName);
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            return await _discountRepository.UpdateDiscount(coupon);
        }
    }
}

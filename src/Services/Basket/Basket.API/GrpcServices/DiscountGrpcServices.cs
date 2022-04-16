using Discount.Grpc.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcServices
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;
        private readonly ILogger<DiscountGrpcServices> _logger;

        public DiscountGrpcServices(DiscountProtoService.DiscountProtoServiceClient discountProtoService, ILogger<DiscountGrpcServices> logger)
        {
            _discountProtoService = discountProtoService;
            _logger = logger;
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            try
            {
                var discountRequest = new GetDiscountRequest { ProductName = productName };
                var couponResponse = await _discountProtoService.GetDiscountAsync(discountRequest);
                return couponResponse;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
            }
            return new CouponModel();
           
        }
    }
}

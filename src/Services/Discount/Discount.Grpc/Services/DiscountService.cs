using AutoMapper;
using Discount.Grpc.Data;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountInteractor _discountInteractor;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountInteractor discountInteractor, ILogger<DiscountService> logger, IMapper mapper)
        {
            _discountInteractor = discountInteractor;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            try
            {
                var coupon = await _discountInteractor.GetDiscount(request.ProductName);
                if (coupon != null)
                {
                    var couponModel = _mapper.Map<CouponModel>(coupon);
                    context.Status = new Status(StatusCode.OK, "coupon retireved successfully");
                    return couponModel;
                }
                
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong : {ex.Message}");
            }
            context.Status = new Status(StatusCode.NotFound, "Coupon retireve failed");
            return new CouponModel();

        }

        public override async Task<CreateDiscountResponse> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var success = await _discountInteractor.CreateDiscount(_mapper.Map<Coupon>(request.Coupon));
            return new CreateDiscountResponse { Success = success };
        }

        public override async Task<UpdateDiscountResponse> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var response = await _discountInteractor.UpdateDiscount(_mapper.Map<Coupon>(request.Coupon));
            return new UpdateDiscountResponse { Updated = response };
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var response = await _discountInteractor.DeleteDiscount(request.ProductName);
            return new DeleteDiscountResponse { Success = response };
        }
    }
}

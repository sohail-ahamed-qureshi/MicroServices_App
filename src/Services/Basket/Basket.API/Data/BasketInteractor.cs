

using System.Threading.Tasks;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;

namespace Basket.API.Data
{
    public class BasketInteractor : IBasketInteractor
    {

        private readonly IBasketRepository _basketRepository;
        private readonly DiscountGrpcServices _grpcServices;
        public BasketInteractor(IBasketRepository basketRepository, DiscountGrpcServices grpcServices)
        {
            _basketRepository = basketRepository;
            _grpcServices = grpcServices;
        }

        public async Task DeleteBasket(string userName)
        {
            await _basketRepository.DeleteBasket(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            return await _basketRepository.GetBasket(userName);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            //check for discount
            foreach (var item in basket.Items)
            {
                var coupon = await _grpcServices.GetDiscount(item.ProductName);
                item.price -=coupon.Amount; //remove discounted amount from actual price
            }
            return await _basketRepository.UpdateBasket(basket);
        }
    }
}

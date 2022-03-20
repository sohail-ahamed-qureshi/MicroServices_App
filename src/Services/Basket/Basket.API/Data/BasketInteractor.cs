

using System.Threading.Tasks;
using Basket.API.Entities;
using Basket.API.Repositories;

namespace Basket.API.Data
{
    public class BasketInteractor : IBasketInteractor
    {

        private readonly IBasketRepository _basketRepository;

        public BasketInteractor(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
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
            return await _basketRepository.UpdateBasket(basket);
        }
    }
}


using System.Threading.Tasks;
using Basket.API.Entities;

namespace Basket.API.Data
{
    public interface IBasketInteractor
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}

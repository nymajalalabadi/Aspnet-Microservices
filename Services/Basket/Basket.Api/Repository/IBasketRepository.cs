using Basket.Api.Entites;
using System.Threading.Tasks;

namespace Basket.Api.Repository
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetUserBasket(string userName);

        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);

        Task DeleteBasket(string userName);
    }
}

using Shopping.Aggregator.Model;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(string userName);
    }
}

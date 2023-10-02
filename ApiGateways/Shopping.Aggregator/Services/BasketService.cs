using Shopping.Aggregator.Model;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        public Task<BasketModel> GetBasket(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}

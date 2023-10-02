using Shopping.Aggregator.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        public Task<IEnumerable<OrderResponseModel>> GetOrderByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}

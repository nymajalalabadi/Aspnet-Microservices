using System.Collections.Generic;

namespace Shopping.Aggregator.Model
{
    public class ShoppingModel
    {
        public string UserName { get; set; }
        public BasketModel BasketWithProduct { get; set; }

        public IEnumerable<OrderResponseModel> Orders { get; set; }
    }
}

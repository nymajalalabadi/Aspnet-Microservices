using System.Collections.Generic;

namespace Shopping.Aggregator.Model
{
    public class BasketModel
    {
        public string UserName { get; set; }

        public decimal TotalPirce { get; set; }

        public List<BasketItemExtendedModel> Items { get; set; } = new List<BasketItemExtendedModel>();
    }
}

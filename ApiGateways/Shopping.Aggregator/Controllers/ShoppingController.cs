using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Model;
using Shopping.Aggregator.Services;
using System.Net;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;

        public ShoppingController(ICatalogService catalogService, IOrderService orderService, IBasketService basketService)
        {
            _catalogService = catalogService;
            _orderService = orderService;
            _basketService = basketService;
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            var basket = await _basketService.GetBasket(userName);

            if (basket != null)
            {
                foreach (var item in basket.Items)
                {
                    var product = await _catalogService.GetCatalog(item.ProductId);

                    item.ProductName = product.Name;
                    item.Category = product.Category;
                    item.Summary = product.Summary;
                    item.Description = product.Description;
                    item.ImageFile = product.ImageFile;
                }
            }

            var orders = await _orderService.GetOrderByUserName(userName);

            var shoppingModel = new ShoppingModel()
            {
                UserName = userName,
                BasketWithProduct = basket,
                Orders = orders
            };

            return Ok(shoppingModel);
        }
    }
}

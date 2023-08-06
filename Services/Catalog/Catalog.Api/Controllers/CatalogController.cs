using Catalog.Api.Entites;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        #region constructor

        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        #endregion

        #region get products

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var product = await _productRepository.GetProducts();
            return Ok(product);
        }

        #endregion


        #region get product by id

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProducts(string id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                _logger.LogError($"product with id: {id} is not found");

                return NotFound();
            }
            return Ok(product);
        }

        #endregion


        #region get product by Category Name

        [HttpGet("[action]/{category}")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
        {
            var product = await _productRepository.GetProductbyCategory(category);
            if (product == null)
            {
                _logger.LogError($"product with category: {category} is not found");

                return NotFound();
            }
            return Ok(product);
        }

        #endregion


        #region create product

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreatePorduct([FromBody] Product product)
        {
            await _productRepository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        #endregion


        #region update product

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePorduct([FromBody] Product product)
        {
            return Ok(await _productRepository.UpdateProduct(product));
        }

        #endregion


        #region delete product

        [HttpDelete("{id:length(24)}", Name = "DeletePorduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePorduct(string id)
        {
            return Ok(await _productRepository.DeleteProduct(id));
        }

        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using Shop.Core.Abstraction;
using Medteh.API.Contracts;
using Shop.Core.Models;

namespace Medteh.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsResponse>>> GetProducts()
        {
            var products = await _productService.GetAllProducts();

            var response = products.Select(b => new ProductsResponse(b.Id, b.Title, b.Description, b.Price));

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> SaveProducts([FromBody] ProductsRequest request)
        {
            var (product, error) = Shop.Core.Models.Product.Create(
                    Guid.NewGuid(),
                    request.Title,
                    request.Description,
                    request.Price);
            if (!string.IsNullOrEmpty(error)){
                return BadRequest(error);
            }

            var productId = await _productService.CreateProduct(product);

            return Ok(productId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateProduct(Guid id, [FromBody] ProductsRequest request)
        {
            var productId = await _productService.UpdateProduct(id, request.Title, request.Description, request.Price);

            return Ok(productId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteProduct(Guid id)
        {
            return Ok(await _productService.DeleteProduct(id));
        }

    }
}

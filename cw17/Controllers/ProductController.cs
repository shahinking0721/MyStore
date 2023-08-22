

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mystore.Data;
using Mystore.Models;

namespace cw17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StoreDbContect _ProductContext;
        public ProductController(StoreDbContect ProductContext)
        {
            _ProductContext = ProductContext;
        }
        [HttpGet]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _ProductContext.Products.FirstOrDefaultAsync(e => e.PruductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPut("EditEmployee")]
        public async Task<ActionResult<Product>> EditProduct(Product product)
        {

            _ProductContext.Products.Update(product);
            await _ProductContext.SaveChangesAsync();
            return Ok();

        }
    }
}

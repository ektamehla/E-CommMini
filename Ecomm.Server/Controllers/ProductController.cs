using Microsoft.EntityFrameworkCore;
using Ecomm.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Ecomm.Server.Data;
using System.Collections.Generic;

namespace Ecomm.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
            //return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductWithId(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpPut]
        //public async Task<ActionResult<Product>> UpdateProduct(Product product)
        //{

        //}
    }
}

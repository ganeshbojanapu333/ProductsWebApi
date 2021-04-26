using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsWebApi.Models;
using ProductsWebApi.Repositories;

namespace ProductsWebApi.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private readonly IProductRepository _ProductRepository;

            public ProductsController(IProductRepository ProductRepository)
            {
                _ProductRepository = ProductRepository;
            }

            [HttpGet]
            public async Task<IEnumerable<Product>> GetProducts()
            {
                return await _ProductRepository.Get();
            }

        [HttpGet("{id}")]
        [ActionName("GetProductbyId")]
        public async Task<ActionResult<Product>> GetProduct(int id)
            {
                return await _ProductRepository.Get(id);
            }

            [HttpPost]
            public async Task<ActionResult<Product>> PostProduct([FromBody] Product Product)
            {
                var newProduct = await _ProductRepository.Create(Product);
                return CreatedAtAction(nameof(GetProducts), new { id = newProduct.id }, newProduct);
            }

            [HttpPut]
            public async Task<ActionResult> PutProduct(int id, [FromBody] Product Product)
            {
                if (id != Product.id)
                {
                    return BadRequest();
                }

                await _ProductRepository.Update(Product);

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(int id)
            {
                var ProductToDelete = await _ProductRepository.Get(id);
                if (ProductToDelete == null)
                    return NotFound();

                await _ProductRepository.Delete(ProductToDelete.id);
                return NoContent();
            }
        }
    
}
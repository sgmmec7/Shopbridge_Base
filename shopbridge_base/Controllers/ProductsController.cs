using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }

       
        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            try
            {
               var products = await productService.GetProduct();
                if (products == null) return NotFound();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var result = ProductExists(id);
                if (result)
                {
                    var product = await productService.GetProduct(id);
                    return Ok(product);
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            try
            {
                if (id == 0 || product == null) return BadRequest();
                var result = ProductExists(id);
                if (result)
                {
                    await productService.PutProduct(id, product);
                    return Ok();
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                if (product == null) return BadRequest();
                await productService.PostProduct(product);
                return CreatedAtAction(nameof(GetProduct), product);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var result = ProductExists(id);
                if (result)
                {
                    await productService.DeleteProduct(id);
                    return Ok();
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        private bool ProductExists(int id)
        {
            return productService.ProductExists(id);
        }
    }
}

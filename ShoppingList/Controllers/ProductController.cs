using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Entities;
using ShoppingList.Services;

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var productsFromRepo = _productRepository.GetProducts();
            return new JsonResult(productsFromRepo);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(Guid id)
        {
            var productFromRepo = _productRepository.GetProduct(id);

            if(productFromRepo == null)
            {
                return NotFound();
            }

            return new JsonResult(productFromRepo);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _productRepository.AddProduct(product);

            if (!_productRepository.Save())
            {
                throw new Exception("Unexpected error while saving product");
            }

            return CreatedAtRoute("GetProduct", new { product.Id }, product);
        }
    }
}

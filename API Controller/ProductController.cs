using iStore.Models;
using iStore.ProductData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iStore.API_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductData productData;
        public ProductController(IProductData data)
        {
            productData = data;
        }
        [HttpGet]
        [Route("GetProductById/{id}")]
        public IActionResult GetProductById(string id)
        {
            var details = productData.GetProductById(id);
            if (details != null)
            {
                return Ok(details);
            }
            return NotFound($"Product with id {id} is not found");

        }
        
        [HttpGet]
        [Route("GetProductByName/{name}")]
        public IActionResult GetProductByName(string name)
        {
            var details = productData.GetProductByName(name);
            if (details != null)
            {
                return Ok(details);
            }
            return NotFound($"Product with Name {name} is not found");

        }

        [HttpPatch]
        [Route("EditProduct/{id}")]
        public IActionResult EditUser(string id, Product u)
        {
            var ExistingUser = productData.GetProductById(id);
            if (ExistingUser != null)
            {
                u.Id = Int32.Parse(id);
                productData.EditProduct(u);
                return Ok();
            }
            return NotFound($"Product with id {id} is not found");
        }
        [HttpGet]
        [Route("GetProductsList")]
        public IActionResult GetProducts()
        {
            return Ok(productData.GetProducts());
        }
        // GET: api/<ProductController>

        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
